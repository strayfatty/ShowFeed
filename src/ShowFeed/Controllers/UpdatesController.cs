namespace ShowFeed.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;

    using MoreLinq;

    using ShowFeed.Models;
    using ShowFeed.Services;
    using ShowFeed.ViewModels;

    using StackExchange.Profiling;

    /// <summary>
    /// The updates controller.
    /// </summary>
    public class UpdatesController : Controller
    {
        /// <summary>
        /// The epoch time.
        /// </summary>
        public static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

        /// <summary>
        /// The database.
        /// </summary>
        private readonly IDatabase database;

        /// <summary>
        /// The series service.
        /// </summary>
        private readonly ISeriesService seriesService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdatesController"/> class.
        /// </summary>
        /// <param name="database">The database.</param>
        /// <param name="seriesService">The series service.</param>
        public UpdatesController(IDatabase database, ISeriesService seriesService)
        {
            this.database = database;
            this.seriesService = seriesService;
        }

        /// <summary>
        /// The index view.
        /// </summary>
        /// <returns>An action result.</returns>
        [HttpGet]
        public ActionResult Index()
        {
            var model = new UpdatesIndexViewModel();
            model.Updates = this.database.Query<Update>()
                .Where(x => x.Finished != 0)
                .OrderByDescending(x => x.Started)
                .Take(10)
                .Select(x => new 
                {
                    Id = x.Id,
                    Started = x.Started,
                    Finished = x.Finished,
                    NumberOfSeriesUpdated = x.Series.Count(),
                    NumberOfEpisodesUpdated = x.Episodes.Count()
                })
                .ToArray()
                .Select(x => new UpdatesIndexViewModel.Update
                {
                    Id = x.Id,
                    Started = Epoch.AddSeconds(x.Started),
                    Duration = new TimeSpan(0, 0, x.Finished - x.Started),
                    NumberOfSeriesUpdated = x.NumberOfSeriesUpdated,
                    NumberOfEpisodesUpdated = x.NumberOfEpisodesUpdated
                })
                .ToArray();

            return this.View(model);
        }

        /// <summary>
        /// The new action.
        /// </summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        [HttpPost]
        public ActionResult New()
        {
            var lastUpdate = this.database.Query<Update>()
                .OrderByDescending(x => x.Started)
                .FirstOrDefault();

            var startTime = DateTime.UtcNow;
            var offset = (int)(startTime.AddHours(-1) - Epoch).TotalSeconds;
            if (lastUpdate == null || lastUpdate.Started < offset)
            {
                var update = new Update();
                update.Started = (int)(startTime - Epoch).TotalSeconds;

                var updateData = this.seriesService.GetUpdateData(lastUpdate != null ? lastUpdate.UpdateTime : 0);

                updateData.Series.Select(x => x.SeriesId)
                    .Union(updateData.Episodes.Select(x => x.SeriesId))
                    .Distinct()
                    .Batch(100)
                    .ForEach(x => this.UpdateBatch(update, updateData, x));

                update.Finished = (int)(DateTime.UtcNow - Epoch).TotalSeconds;
                update.UpdateTime = updateData.UpdateTime;

                this.database.Store(update);
                this.database.SaveChanges();
            }

            return this.RedirectToRoute("updates");
        }

        /// <summary>
        /// Updates a series batch.
        /// </summary>
        /// <param name="update">The update.</param>
        /// <param name="updateData">The update data.</param>
        /// <param name="seriesIds">The series ids.</param>
        private void UpdateBatch(Update update, UpdateData updateData, IEnumerable<int> seriesIds)
        {
            this.database.Query<Series>()
                .Where(x => seriesIds.Contains(x.SeriesId))
                .ToArray()
                .ForEach(x => this.UpdateSeries(update, updateData, x));
        }

        /// <summary>
        /// Update a series.
        /// </summary>
        /// <param name="update">The update.</param>
        /// <param name="updateData">The update data.</param>
        /// <param name="series">The series.</param>
        private void UpdateSeries(Update update, UpdateData updateData, Series series)
        {
            using (MiniProfiler.Current.Step("update series"))
            {
                var seriesData = this.seriesService.GetDetails(series.SeriesId);

                Mapper.Map(seriesData.Series, series);
                series.Updates.Add(update);
                
                foreach (var updatedEpisode in updateData.Episodes.Where(x => x.SeriesId == series.SeriesId))
                {
                    var episode = series.Episodes.FirstOrDefault(x => x.EpisodeId == updatedEpisode.EpisodeId);
                    var episodeRecord = seriesData.Episodes.FirstOrDefault(x => x.EpisodeId == updatedEpisode.EpisodeId);

                    if (episode != null)
                    {
                        if (episodeRecord == null)
                        {
                            series.Episodes.Remove(episode);
                        }
                        else
                        {
                            Mapper.Map(episodeRecord, episode);
                            episode.Updates.Add(update);
                        }
                    }
                    else if (episodeRecord != null)
                    {
                        episode = Mapper.Map<Episode>(episodeRecord);
                        episode.Updates.Add(update);
                        series.Episodes.Add(episode);
                    }
                }
            }
        }
    }
}