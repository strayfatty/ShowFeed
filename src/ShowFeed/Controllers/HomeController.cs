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
        public ActionResult Upcoming()
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
            ////model.Shows = this.database.Query<TvShow>()
            ////    .Where(x => x.Followers.Any(y => y.Username == WebSecurity.CurrentUserName))
            ////    .Select(x => new HomeFollowingViewModel.Show
            ////        {
            ////            Id = x.Id,
            ////            Name = x.Name,
            ////            Description = x.Description,
            ////        })
            ////    .ToArray();

            return this.View(model);
        }

        /// <summary>
        /// The search TV show view.
        /// </summary>
        /// <returns>An action result.</returns>
        [HttpGet]
        public ActionResult SearchTvShow()
        {
            return this.View(new HomeSearchTvShowViewModel());
        }

        /// <summary>
        /// The search TV show action.
        /// </summary>
        /// <param name="showName">The show name.</param>
        /// <returns>An action result.</returns>
        [HttpPost]
        public ActionResult SearchTvShow(string showName)
        {
            ////var followedSeries = this.database.Query<User>()
            ////    .Where(x => x.Username == WebSecurity.CurrentUserName)
            ////    .SelectMany(x => x.FollowedSeries)
            ////    .Select(x => x.SeriesId)
            ////    .ToArray();

            ////var model = new HomeSearchTvShowViewModel();
            ////model.ShowName = showName;
            ////model.Shows = this.seriesService.Search(showName)
            ////    .Select(x => new HomeSearchTvShowViewModel.Show
            ////    {
            ////        ShowId = x.SeriesId,
            ////        Name = x.Name,
            ////        Description = x.Description,
            ////        Following = tvShowsFollowing.Contains(x.SeriesId)
            ////    })
            ////    .ToArray();

            ////return this.View(model);
            return this.View(new HomeSearchTvShowViewModel());
        }
    }
}
