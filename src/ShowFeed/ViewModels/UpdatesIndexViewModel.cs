namespace ShowFeed.ViewModels
{
    using System;

    /// <summary>
    /// The updates index view model.
    /// </summary>
    public class UpdatesIndexViewModel
    {
        /// <summary>
        /// Gets or sets the updates.
        /// </summary>
        public Update[] Updates { get; set; }

        /// <summary>
        /// The update.
        /// </summary>
        public class Update
        {
            /// <summary>
            /// Gets or sets the id.
            /// </summary>
            public int Id { get; set; }

            /// <summary>
            /// Gets or sets the started.
            /// </summary>
            public DateTime Started { get; set; }

            /// <summary>
            /// Gets or sets the duration.
            /// </summary>
            public TimeSpan Duration { get; set; }

            /// <summary>
            /// Gets or sets the number of series updated.
            /// </summary>
            public int NumberOfSeriesUpdated { get; set; }

            /// <summary>
            /// Gets or sets the number of episodes updated.
            /// </summary>
            public int NumberOfEpisodesUpdated { get; set; }
        }
    }
}