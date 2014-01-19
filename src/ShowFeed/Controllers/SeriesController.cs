namespace ShowFeed.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;

    using ShowFeed.Models;
    using ShowFeed.ViewModels;

    using WebMatrix.WebData;

    /// <summary>
    /// The series controller.
    /// </summary>
    public class SeriesController : Controller
    {
        /// <summary>
        /// The database.
        /// </summary>
        private readonly IDatabase database;

        /// <summary>
        /// Initializes a new instance of the <see cref="SeriesController"/> class.
        /// </summary>
        /// <param name="database">The database.</param>
        public SeriesController(IDatabase database)
        {
            this.database = database;
        }

        /// <summary>
        /// The index view.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index()
        {
            var model = new SeriesIndexViewModel();
            model.Entries = this.database.Query<Series>()
                .Select(
                    x => new SeriesIndexViewModel.Series
                    {
                        SeriesId = x.SeriesId,
                        Name = x.Name,
                        Following = x.Followers.Any(y => y.Username == WebSecurity.CurrentUserName)
                    })
                .ToArray();

            return this.View(model);
        }

        /// <summary>
        /// The details view.
        /// </summary>
        /// <param name="id">The series id.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            var series = this.database.Query<Series>().FirstOrDefault(x => x.SeriesId == id);
            if (series == null)
            {
                return this.RedirectToRoute("series");
            }

            var model = Mapper.Map<SeriesDetailsViewModel>(series);
            return this.View(model);
        }
    }
}