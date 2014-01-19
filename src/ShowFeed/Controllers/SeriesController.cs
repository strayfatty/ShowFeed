namespace ShowFeed.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

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
    }
}