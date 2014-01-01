namespace ShowFeed.Api.Model
{
    using System;

    /// <summary>
    /// The calendar query.
    /// </summary>
    public class CalendarQuery
    {
        /// <summary>
        /// Gets the from date.
        /// </summary>
        public DateTime FromDate
        {
            get
            {
                return CalendarEntry.Epoch.AddSeconds(this.From / 1000.0);
            }
        }

        /// <summary>
        /// Gets the to date.
        /// </summary>
        public DateTime ToDate
        {
            get
            {
                return CalendarEntry.Epoch.AddSeconds(this.To / 1000.0);
            }
        }

        /// <summary>
        /// Gets or sets the from UTC time stamp.
        /// </summary>
        public long From { get; set; }

        /// <summary>
        /// Gets or sets the to UTC time stamp.
        /// </summary>
        public long To { get; set; }
    }
}