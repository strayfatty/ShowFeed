﻿namespace ShowFeed.Api.Model
{
    using System;

    /// <summary>
    /// The calendar entry.
    /// </summary>
    public class CalendarEntry
    {
        /// <summary>
        /// The epoch time.
        /// </summary>
        public static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the url.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the class.
        /// </summary>
        public string Class { get; set; }

        /// <summary>
        /// Gets the start.
        /// </summary>
        public long Start
        {
            get
            {
                return (long)(this.EventDay - Epoch).TotalSeconds * 1000;
            }
        }

        /// <summary>
        /// Gets the end.
        /// </summary>
        public long End
        {
            get
            {
                return (long)(this.EventDay - Epoch).TotalSeconds * 1000;
            }
        }

        /// <summary>
        /// Gets or sets the event day.
        /// </summary>
        public DateTime EventDay { get; set; }
    }
}