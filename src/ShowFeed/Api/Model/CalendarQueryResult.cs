namespace ShowFeed.Api.Model
{
    using System.Collections.Generic;

    /// <summary>
    /// The calendar query result.
    /// </summary>
    public class CalendarQueryResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CalendarQueryResult"/> class.
        /// </summary>
        public CalendarQueryResult()
        {
            this.Result = new List<CalendarEntry>();
        }

        /// <summary>
        /// Gets or sets the success.
        /// </summary>
        public int Success { get; set; }

        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        public IList<CalendarEntry> Result { get; set; }
    }
}