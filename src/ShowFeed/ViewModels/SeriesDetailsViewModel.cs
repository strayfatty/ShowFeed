namespace ShowFeed.ViewModels
{
    using System;

    /// <summary>
    /// The series details view model.
    /// </summary>
    public class SeriesDetailsViewModel
    {
        /// <summary>
        /// Gets or sets the series id.
        /// </summary>
        public virtual int SeriesId { get; set; }

        /// <summary>
        /// Gets or sets the IMDB id.
        /// </summary>
        public virtual string ImdbId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        /// Gets or sets the episodes.
        /// </summary>
        public Episode[] Episodes { get; set; }

        /// <summary>
        /// The episode.
        /// </summary>
        public class Episode
        {
            /// <summary>
            /// Gets or sets the episode id.
            /// </summary>
            public virtual int EpisodeId { get; set; }

            /// <summary>
            /// Gets or sets the season number.
            /// </summary>
            public virtual int SeasonNumber { get; set; }

            /// <summary>
            /// Gets or sets the episode number in its season.
            /// </summary>
            public virtual int EpisodeNumber { get; set; }

            /// <summary>
            /// Gets or sets the name.
            /// </summary>
            public virtual string Name { get; set; }

            /// <summary>
            /// Gets or sets the description.
            /// </summary>
            public virtual string Description { get; set; }

            /// <summary>
            /// Gets or sets the first aired date.
            /// </summary>
            public virtual DateTime? FirstAired { get; set; }
        }
    }
}
