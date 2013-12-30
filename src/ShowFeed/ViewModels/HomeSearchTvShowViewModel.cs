namespace ShowFeed.ViewModels
{
    /// <summary>
    /// The home following view model.
    /// </summary>
    public class HomeSearchTvShowViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HomeSearchTvShowViewModel"/> class.
        /// </summary>
        public HomeSearchTvShowViewModel()
        {
            this.ShowName = string.Empty;
            this.Shows = new Show[0];
        }

        /// <summary>
        /// Gets or sets the show name.
        /// </summary>
        public string ShowName { get; set; }

        /// <summary>
        /// Gets or sets the shows.
        /// </summary>
        public Show[] Shows { get; set; }

        /// <summary>
        /// The show.
        /// </summary>
        public class Show
        {
            /// <summary>
            /// Gets or sets the show id.
            /// </summary>
            public int ShowId { get; set; }

            /// <summary>
            /// Gets or sets the name.
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// Gets or sets the description.
            /// </summary>
            public string Description { get; set; }

            /// <summary>
            /// Gets or sets the link.
            /// </summary>
            public string Link { get; set; }

            /// <summary>
            /// Gets or sets a value indicating whether the user is 
            /// already following the show.
            /// </summary>
            public bool Following { get; set; }
        }
    }
}