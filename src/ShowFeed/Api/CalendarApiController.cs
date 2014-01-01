namespace ShowFeed.Api
{
    using System;
    using System.Linq;
    using System.Web.Http;

    using ShowFeed.Api.Model;
    using ShowFeed.Models;

    using WebMatrix.WebData;

    /// <summary>
    /// The calendar API controller.
    /// </summary>
    public class CalendarApiController : ApiController
    {
        /// <summary>
        /// The database.
        /// </summary>
        private readonly IDatabase database;

        /// <summary>
        /// Initializes a new instance of the <see cref="CalendarApiController"/> class.
        /// </summary>
        /// <param name="database">The database.</param>
        public CalendarApiController(IDatabase database)
        {
            this.database = database;
        }

        /// <summary>
        /// Gets the calendar events for the specified time frame.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>The <see cref="CalendarQueryResult"/>.</returns>
        [HttpGet]
        public CalendarQueryResult Get([FromUri]CalendarQuery query)
        {
            var result = new CalendarQueryResult();
            result.Success = 1;

            result.Result = this.database.Query<Episode>()
                .Where(x => x.FirstAired.HasValue
                    && x.FirstAired.Value >= query.FromDate
                    && x.FirstAired.Value <= query.ToDate)
                .Select(x => new CalendarEntry
                    {
                        Id = x.Id,
                        Title = x.Series.Name + " - " + x.Name,
                        Class = x.FirstAired.Value >= DateTime.Today ? "event-info" : x.Viewers.Any(y => y.Username == WebSecurity.CurrentUserName) ? "event-success" : "event-important",
                        EventDay = x.FirstAired.Value
                    })
                .ToList();

            return result;
        }
    }
}