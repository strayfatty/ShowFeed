namespace ShowFeed.ViewModels
{
    /// <summary>
    /// The series index view model.
    /// </summary>
    public class SeriesIndexViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SeriesIndexViewModel"/> class.
        /// </summary>
        public SeriesIndexViewModel()
        {
            this.Entries = new Series[0];
        }

        /// <summary>
        /// Gets or sets the series.
        /// </summary>
        public Series[] Entries { get; set; }

        /// <summary>
        /// The series.
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

            /// <summary>
            /// Gets or sets a value indicating whether the user is 
            /// already following the show.
            /// </summary>
            public bool Following { get; set; }
        }
    }
}