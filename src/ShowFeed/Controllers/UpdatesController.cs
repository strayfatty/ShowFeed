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
            var offset = (int)(startTime.AddSeconds(-10) - CalendarEntry.Epoch).TotalSeconds;
            if (lastUpdate == null || lastUpdate.Started < offset)
            {
                var update = new Update();
                update.Started = (int)(startTime - CalendarEntry.Epoch).TotalSeconds;

                var updateData = this.seriesService.GetUpdateData(lastUpdate != null ? lastUpdate.UpdateTime : 0);
                this.UpdateSeries(update, updateData.Series);
                this.UpdateEpisodes(update, updateData.Episodes);

                update.Finished = (int)(DateTime.UtcNow - CalendarEntry.Epoch).TotalSeconds;
                update.UpdateTime = updateData.UpdateTime;

                this.database.Store(update);
                this.database.SaveChanges();
            }

            return this.RedirectToRoute("updates");
        }

        private void UpdateSeries(Update update, IEnumerable<ISeriesUpdateRecord> records)
        {
            using (MiniProfiler.Current.Step("update series"))
            {
                foreach (var record in records)
                {
                    var series = this.database.Load<Series>(record.SeriesId);
                    if (series == null)
                    {
                        continue;
                    }

                    ////var baseSeriesRecord = this.seriesService.GetBaseSeriesRecord(record.SeriesId);
                    ////Mapper.Map(baseSeriesRecord, series);
                    ////update.Series.Add(series);
                }
            }
        }

        private void UpdateEpisodes(Update update, IEnumerable<IEpisodeUpdateRecord> records)
        {
            using (MiniProfiler.Current.Step("update series"))
            {
            }
        }
    }
}