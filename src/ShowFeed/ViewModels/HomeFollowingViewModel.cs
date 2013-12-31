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
            this.Shows = new Show[0];
        }

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
            /// Gets or sets the id.
            /// </summary>
            public int Id { get; set; }

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