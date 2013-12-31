namespace ShowFeed.ViewModels
{
    /// <summary>
    /// The home following view model.
    /// </summary>
    public class HomeSearchSeriesViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HomeSearchSeriesViewModel"/> class.
        /// </summary>
        public HomeSearchSeriesViewModel()
        {
            this.Query = string.Empty;
            this.Result = new Series[0];
        }

        /// <summary>
        /// Gets or sets the show name.
        /// </summary>
        public string Query { get; set; }

        /// <summary>
        /// Gets or sets the shows.
        /// </summary>
        public Series[] Result { get; set; }

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
            /// Gets or sets the IMDB id.
            /// </summary>
            public string ImdbId { get; set; }

            /// <summary>
            /// Gets or sets the name.
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// Gets or sets the description.
            /// </summary>
            public string Description { get; set; }

            /// <summary>
            /// Gets or sets a value indicating whether the user is 
            /// already following the show.
            /// </summary>
            public bool Following { get; set; }
        }
    }
}