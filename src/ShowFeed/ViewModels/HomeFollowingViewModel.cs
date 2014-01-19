namespace ShowFeed.ViewModels
{
    /// <summary>
    /// The home following view model.
    /// </summary>
    public class HomeFollowingViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HomeFollowingViewModel"/> class.
        /// </summary>
        public HomeFollowingViewModel()
        {
            this.Entries = new Series[0];
        }

        /// <summary>
        /// Gets or sets the shows.
        /// </summary>
        public Series[] Entries { get; set; }

        /// <summary>
        /// The show.
        /// </summary>
        public class Series
        {
            /// <summary>
            /// Gets or sets the series id.
            /// </summary>
            public int SeriesId { get; set; }

            /// <summary>
            /// Gets or sets the name.
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// Gets or sets the description.
            /// </summary>
            public string Description { get; set; }
        }
    }
}