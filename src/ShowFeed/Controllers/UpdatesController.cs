namespace ShowFeed.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using ShowFeed.Jobs;
    using ShowFeed.Models;
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
        /// Initializes a new instance of the <see cref="UpdatesController"/> class.
        /// </summary>
        /// <param name="database">The database.</param>
        public UpdatesController(IDatabase database)
        {
            this.database = database;
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

        /// <summary>
        /// The details view.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        [HttpGet]
        public ActionResult Details(int id)
        {
            var update = this.database.Load<Update>(id);

            var model = new UpdatesDetailsViewModel();
            model.Started = UpdateJob.Epoch.AddSeconds(update.Started);

            model.Episodes = this.database.Query<Episode>()
                .Where(x => x.Updates.Any(y => y.Id == id))
                .Select(x => new UpdatesDetailsViewModel.Episode
                {
                    SeriesId = x.Series.SeriesId,
                    SeriesName = x.Series.Name,
                    SeasonNumber = x.SeasonNumber,
                    EpisodeNumber = x.EpisodeNumber,
                    EpisodeName = x.Name
                })
                .ToArray();

            return this.View(model);
        }
    }
}