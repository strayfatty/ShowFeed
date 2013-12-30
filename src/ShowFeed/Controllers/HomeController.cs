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
        /// The TV show service.
        /// </summary>
        private readonly ITvShowService tvShowService;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="database">The database.</param>
        /// <param name="tvShowService">The TV show service.</param>
        public HomeController(IDatabase database, ITvShowService tvShowService)
        {
            this.database = database;
            this.tvShowService = tvShowService;
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
            model.Shows = this.database.Query<TvShow>()
                .Where(x => x.Followers.Any(y => y.Username == WebSecurity.CurrentUserName))
                .Select(x => new HomeFollowingViewModel.Show
                    {
                        Id = x.Id,
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
            var tvShowsFollowing = this.database.Query<User>()
                .Where(x => x.Username == WebSecurity.CurrentUserName)
                .SelectMany(x => x.TvShowsFollowing)
                .Select(x => x.SourceId)
                .ToArray();

            var model = new HomeSearchTvShowViewModel();
            model.ShowName = showName;
            model.Shows = this.tvShowService.Search(showName)
                .Select(x => new HomeSearchTvShowViewModel.Show
                {
                    ShowId = x.SourceId,
                    Name = x.Name,
                    Description = x.Description,
                    Link = x.SourceLink,
                    Following = tvShowsFollowing.Contains(x.SourceId)
                })
                .ToArray();

            return this.View(model);
        }
    }
}
