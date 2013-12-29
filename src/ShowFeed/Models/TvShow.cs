namespace ShowFeed.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// The TV show class.
    /// </summary>
    [Table("TvShow")]
    public class TvShow : Entity
    {
        /// <summary>
        /// Gets or sets the TVRage.com id for the show.
        /// </summary>
        public virtual int SourceId { get; set; }

        /// <summary>
        /// Gets or sets the link to TVRage.com for the show.
        /// </summary>
        public virtual string SourceLink { get; set; }

        /// <summary>
        /// Gets or sets the image link to TVRage.com for the show.
        /// </summary>
        public virtual string SourceImageLink { get; set; }

        /// <summary>
        /// Gets or sets the name of the show.
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// Gets or sets the description for the show.
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        /// Gets or sets the episodes.
        /// </summary>
        public virtual ICollection<TvEpisode> Episodes { get; set; }

        /// <summary>
        /// Gets or sets the user that follow to the show.
        /// </summary>
        public virtual ICollection<User> Followers { get; set; }
    }
}