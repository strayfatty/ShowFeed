namespace ShowFeed.Models
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The episode.
    /// </summary>
    public class Episode ////: Entity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Episode"/> class.
        /// </summary>
        public Episode()
        {
        }

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

        /// <summary>
        /// Gets or sets the image link.
        /// </summary>
        public virtual string ImageLink { get; set; }

        /// <summary>
        /// Gets or sets the series.
        /// </summary>
        public virtual Series Series { get; set; }

        /// <summary>
        /// Gets or sets the viewers.
        /// </summary>
        public virtual ICollection<User> Viewers { get; set; }
    }
}