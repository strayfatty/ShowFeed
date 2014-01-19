namespace ShowFeed.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using ShowFeed.Models;
    using ShowFeed.Services;
    using ShowFeed.ViewModels;

    using WebMatrix.WebData;

    /// <summary>
    /// The home controller.
    /// </summary>
    public class HomeController : Controller
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
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="database">The database.</param>
        /// <param name="seriesService">The series service.</param>
        public HomeController(IDatabase database, ISeriesService seriesService)
        {
            this.database = database;
            this.seriesService = seriesService;
        }

        /// <summary>
        /// The index view.
        /// </summary>
        /// <returns>An action result.</returns>
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index()
        {
            return this.View();
        }

        /// <summary>
        /// The upcoming view.
        /// </summary>
        /// <returns>An action result.</returns>
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Calendar()
        {
            return this.View();
        }

        /// <summary>
        /// The following view.
        /// </summary>
        /// <returns>An action result.</returns>
        [HttpGet]
        public ActionResult Following()
        {
            var model = new HomeFollowingViewModel();
            model.Entries = this.database.Query<Series>()
                .Where(x => x.Followers.Any(y => y.Username == WebSecurity.CurrentUserName))
                .Select(x => new HomeFollowingViewModel.Series
                    {
                        SeriesId = x.SeriesId,
                        Name = x.Name,
                        Description = x.Description,
                    })
                .ToArray();

            return this.View(model);
        }

        /// <summary>
        /// The search TV show view.
        /// </summary>
        /// <returns>An action result.</returns>
        [HttpGet]
        public ActionResult SearchSeries()
        {
            return this.View(new HomeSearchSeriesViewModel());
        }

        /// <summary>
        /// The search TV show action.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>An action result.</returns>
        [HttpPost]
        public ActionResult SearchSeries(string query)
        {
            var followedSeries = this.database.Query<User>()
                .Where(x => x.Username == WebSecurity.CurrentUserName)
                .SelectMany(x => x.FollowedSeries)
                .Select(x => x.SeriesId)
                .ToArray();

            var model = new HomeSearchSeriesViewModel();
            model.Query = query;
            model.Result = this.seriesService.Search(query)
                .Select(x => new HomeSearchSeriesViewModel.Series
                {
                    SeriesId = x.SeriesId,
                    ImdbId = x.ImdbId,
                    Name = x.Name,
                    Description = x.Description,
                    Following = followedSeries.Contains(x.SeriesId)
                })
                .ToArray();

            return this.View(model);
        }
    }
}
