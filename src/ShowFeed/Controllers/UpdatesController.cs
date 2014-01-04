namespace ShowFeed.Controllers
{
    using System.Web.Mvc;

    using ShowFeed.Models;
    using ShowFeed.Services;

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
            return this.View();
        }

        /// <summary>
        /// The new action.
        /// </summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        [HttpPost]
        public ActionResult New()
        {
            return this.RedirectToRoute("updates");
        }
    }
}