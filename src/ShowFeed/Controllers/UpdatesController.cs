namespace ShowFeed.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;

    using ShowFeed.Api.Model;
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
                    Started = CalendarEntry.Epoch.AddSeconds(x.Started),
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
            var offset = (int)(startTime.AddHours(-1) - CalendarEntry.Epoch).TotalSeconds;
            if (lastUpdate == null || lastUpdate.Started < offset)
            {
                var update = new Update();
                update.Started = (int)(startTime - CalendarEntry.Epoch).TotalSeconds;

                var updateData = this.seriesService.GetUpdateData(lastUpdate != null ? lastUpdate.UpdateTime : 0);

                var seriesIds = updateData.Series.Select(x => x.SeriesId)
                    .Union(updateData.Episodes.Select(x => x.SeriesId))
                    .Distinct();

                foreach (var seriesId in seriesIds)
                {
                    var id = seriesId;
                    var updatedEpisodes = updateData.Episodes.Where(x => x.SeriesId == id)
                                                    .Select(x => x.EpisodeId);

                    this.Update(update, seriesId, updatedEpisodes);
                }

                update.Finished = (int)(DateTime.UtcNow - CalendarEntry.Epoch).TotalSeconds;
                update.UpdateTime = updateData.UpdateTime;

                this.database.Store(update);
                this.database.SaveChanges();
            }

            return this.RedirectToRoute("updates");
        }

        /// <summary>
        /// Update a series.
        /// </summary>
        /// <param name="update">The update.</param>
        /// <param name="seriesId">The series id.</param>
        /// <param name="updatedEpisodes">The updated episodes.</param>
        private void Update(Update update, int seriesId, IEnumerable<int> updatedEpisodes)
        {
            using (MiniProfiler.Current.Step("update series"))
            {
                var series = this.database.Load<Series>(seriesId);
                if (series == null)
                {
                    return;
                }

                var seriesData = this.seriesService.GetDetails(seriesId);

                Mapper.Map(seriesData.Series, series);
                series.Updates.Add(update);
                
                foreach (var episodeId in updatedEpisodes)
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