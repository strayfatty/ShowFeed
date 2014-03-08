namespace ShowFeed.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using ShowFeed.Jobs;
    using ShowFeed.Models;
    using ShowFeed.Services;
    using ShowFeed.ViewModels;

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
                    Started = UpdateJob.Epoch.AddSeconds(x.Started),
                    Duration = new TimeSpan(0, 0, x.Finished - x.Started),
                    NumberOfSeriesUpdated = x.NumberOfSeriesUpdated,
                    NumberOfEpisodesUpdated = x.NumberOfEpisodesUpdated
                })
                .ToArray();

            return this.View(model);
        }
    }
}