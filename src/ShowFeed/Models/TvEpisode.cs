namespace ShowFeed.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// The TV episode class.
    /// </summary>
    [Table("TvEpisode")]
    public class TvEpisode : Entity
    {
        /// <summary>
        /// Gets or sets the link to TVRage.com for the episode.
        /// </summary>
        public virtual string SourceLink { get; set; }

        /// <summary>
        /// Gets or sets the image link to TVRage.com for the episode.
        /// </summary>
        public virtual string SourceImageLink { get; set; }

        /// <summary>
        /// Gets or sets the season.
        /// </summary>
        public virtual int Season { get; set; }

        /// <summary>
        /// Gets or sets the index for the episode within the season.
        /// </summary>
        /// <remarks>
        /// Specials do not have an index, their index is 0.
        /// </remarks>
        public virtual int Index { get; set; }

        /// <summary>
        /// Gets or sets the episode title.
        /// </summary>
        public virtual string Title { get; set; }

        /// <summary>
        /// Gets or sets the episode summary.
        /// </summary>
        public virtual string Summary { get; set; }

        /// <summary>
        /// Gets or sets the air date.
        /// </summary>
        public virtual DateTime? AirDate { get; set; }

        /// <summary>
        /// Gets or sets the show the episode belongs to.
        /// </summary>
        public virtual TvShow Show { get; set; }

        /// <summary>
        /// Gets or sets the users that have viewed the episode.
        /// </summary>
        public virtual ICollection<User> Viewers { get; set; }
    }
}