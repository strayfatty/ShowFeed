namespace ShowFeed.ViewModels
{
    using System;

    /// <summary>
    /// The updates index view model.
    /// </summary>
    public class UpdatesDetailsViewModel
    {
        /// <summary>
        /// Gets or sets the started.
        /// </summary>
        public DateTime Started { get; set; }

        /// <summary>
        /// Gets or sets the updates.
        /// </summary>
        public Episode[] Episodes { get; set; }

        /// <summary>
        /// The update.
        /// </summary>
        public class Episode
        {
            /// <summary>
            /// Gets or sets the id.
            /// </summary>
            public int SeriesId { get; set; }

            /// <summary>
            /// Gets or sets the series name.
            /// </summary>
            public string SeriesName { get; set; }

            /// <summary>
            /// Gets or sets the season number.
            /// </summary>
            public virtual int SeasonNumber { get; set; }

            /// <summary>
            /// Gets or sets the episode number in its season.
            /// </summary>
            public virtual int EpisodeNumber { get; set; }

            /// <summary>
            /// Gets or sets the episode name.
            /// </summary>
            public string EpisodeName { get; set; }
        }
    }
}