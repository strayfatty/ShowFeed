namespace ShowFeed.Jobs
{
    using System;
    using System.Configuration;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;

    using MoreLinq;

    using ShowFeed.Models;
    using ShowFeed.Services;

    /// <summary>
    /// The update job.
    /// </summary>
    public class UpdateJob : IRecurringJob
    {
        /// <summary>
        /// The epoch time.
        /// </summary>
        public static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        
        /// <summary>
        /// Gets the interval.
        /// </summary>
        public TimeSpan Interval
        {
            get
            {
                var delayInHours = (int)Convert.ChangeType(ConfigurationManager.AppSettings["UpdateIntervalInHours"], typeof(int));
                return new TimeSpan(delayInHours, 0, 0);
            }
        }

        /// <summary>
        /// Runs the job.
        /// </summary>
        public void Run()
        {
            var update = new Update();
            update.Started = (int)(DateTime.UtcNow - Epoch).TotalSeconds;

            var database = DependencyResolver.Current.GetService<IDatabase>();
            var seriesService = DependencyResolver.Current.GetService<ISeriesService>();

            var lastUpdateTime = database.Query<Update>()
                .OrderByDescending(x => x.Started)
                .Select(x => x.UpdateTime)
                .FirstOrDefault();

            var updateData = seriesService.GetUpdateData(lastUpdateTime);
            update.UpdateTime = updateData.UpdateTime;

            database.Store(update);
            database.SaveChanges();

            var batches = updateData.Series.Select(x => x.SeriesId)
                .Union(updateData.Episodes.Select(x => x.SeriesId))
                .Distinct()
                .Batch(100);

            foreach (var batch in batches)
            {
                var seriesToUpdate = database.Query<Series>()
                    .Where(x => batch.Contains(x.SeriesId))
                    .ToArray();

                foreach (var series in seriesToUpdate)
                {
                    var seriesData = seriesService.GetDetails(series.SeriesId);
                    Mapper.Map(seriesData.Series, series);
                    update.Series.Add(series);

                    var episodeIds = updateData.Episodes.Where(x => x.SeriesId == series.SeriesId).Select(x => x.EpisodeId);
                    foreach (var episodeId in episodeIds)
                    {
                        var episode = series.Episodes.FirstOrDefault(x => x.EpisodeId == episodeId);
                        var episodeRecord = seriesData.Episodes.FirstOrDefault(x => x.EpisodeId == episodeId);

                        if (episode != null)
                        {
                            if (episodeRecord == null)
                            {
                                series.Episodes.Remove(episode);
                            }
                            else
                            {
                                Mapper.Map(episodeRecord, episode);
                                update.Episodes.Add(episode);
                            }
                        }
                        else
                        {
                            episode = Mapper.Map<Episode>(episodeRecord);
                            series.Episodes.Add(episode);
                            update.Episodes.Add(episode);
                        }
                    }

                    database.SaveChanges();
                }
            }

            update.Finished = (int)(DateTime.UtcNow - Epoch).TotalSeconds;
            database.SaveChanges();
        }
    }
}
