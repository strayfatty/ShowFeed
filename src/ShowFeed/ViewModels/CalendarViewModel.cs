namespace ShowFeed.ViewModels
{
    using System;

    /// <summary>
    /// The calendar day view model.
    /// </summary>
    public class CalendarViewModel
    {
        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the episodes.
        /// </summary>
        public CalendarEpisodeViewModel[] Episodes { get; set; }
    }
}