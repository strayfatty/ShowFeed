namespace ShowFeed.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using ShowFeed.Models;

    using WebMatrix.WebData;

    /// <summary>
    /// The calendar controller.
    /// </summary>
    public class CalendarController : Controller
    {
        /// <summary>
        /// The database.
        /// </summary>
        private readonly IDatabase database;

        /// <summary>
        /// Initializes a new instance of the <see cref="CalendarController"/> class.
        /// </summary>
        /// <param name="database">The database.</param>
        public CalendarController(IDatabase database)
        {
            this.database = database;
        }

        /// <summary>
        /// The index view.
        /// </summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index()
        {
            return this.RedirectToAction("Day", new { year = DateTime.Today.Year, month = DateTime.Today.Month, day = DateTime.Today.Day });
        }

        /// <summary>
        /// The month view.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="month">The month.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Month(int year, int month)
        {
            var date = new DateTime(year, month, 1);
            var end = date.AddMonths(1);
            return this.View(date);
        }

        /// <summary>
        /// The day view.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="month">The month.</param>
        /// <param name="day">The day.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Day(int year, int month, int day)
        {
            var date = new DateTime(year, month, day);
            var start = date.AddDays(-3);
            var end = date.AddDays(4);
            return this.View(date);
        }

        private void GetEpisodes(DateTime start, DateTime end)
        {
            var username = WebSecurity.CurrentUserName;
            var databaseQuery = this.database.Query<Episode>()
                .Where(x => x.FirstAired.HasValue
                    && x.FirstAired.Value >= start
                    && x.FirstAired.Value < end);

            if (this.User.Identity.IsAuthenticated)
            {
                databaseQuery = databaseQuery.Where(x => x.Series.Followers.Any(y => y.Username == username));
            }

            ////return databaseQuery.Select(x => new CalendarEntry
            ////{
            ////    Id = x.Id,
            ////    Title = x.Series.Name,
            ////    SeasonNumber = x.SeasonNumber,
            ////    EpisodeNumber = x.EpisodeNumber,
            ////    EpisodeTitle = x.Name,
            ////    Class = x.FirstAired.Value >= DateTime.Today ? "event-info" : x.Viewers.Any(y => y.Username == WebSecurity.CurrentUserName) ? "event-success" : "event-important",
            ////    EventDay = x.FirstAired.Value
            ////})
            ////    .ToList();
        }
    }
}