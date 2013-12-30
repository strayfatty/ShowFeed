namespace ShowFeed.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using ShowFeed.Models;
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
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="database">The database.</param>
        public HomeController(IDatabase database)
        {
            this.database = database;
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
            var model = new HomeSearchTvShowViewModel();
            model.ShowName = showName;
            // TODO: model.Shows = ...;

            model.Shows = new []
            {
                new HomeSearchTvShowViewModel.Show
                {
                    ShowId = 3333,
                    Name = "Doctor Who (2005)",
                    Description = string.Empty,
                    Link = "...",
                    Following = false
                },
                new HomeSearchTvShowViewModel.Show
                {
                    ShowId = 3334,
                    Name = "Doctor Who",
                    Description = string.Empty,
                    Link = "...",
                    Following = true
                },
            };

            return this.View(model);
        }
    }
}
