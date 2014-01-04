namespace ShowFeed.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// The series.
    /// </summary>
    [Table("Series")]
    public class Series : Entity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Series"/> class.
        /// </summary>
        public Series()
        {
            this.Episodes = new List<Episode>();
            this.Followers = new List<User>();
        }

        /// <summary>
        /// Gets or sets the series id.
        /// </summary>
        public virtual int SeriesId { get; set; }

        /// <summary>
        /// Gets or sets the IMDB id.
        /// </summary>
        [MaxLength(25)]
        public virtual string ImdbId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [MaxLength(255)]
        public virtual string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        /// Gets or sets the banner link.
        /// </summary>
        [MaxLength(255)]
        public virtual string BannerLink { get; set; }

        /// <summary>
        /// Gets or sets the fan art link.
        /// </summary>
        [MaxLength(255)]
        public virtual string FanArtLink { get; set; }

        /// <summary>
        /// Gets or sets the poster link.
        /// </summary>
        [MaxLength(255)]
        public virtual string PosterLink { get; set; }

        /// <summary>
        /// Gets or sets the episodes.
        /// </summary>
        public virtual ICollection<Episode> Episodes { get; set; }

        /// <summary>
        /// Gets or sets the user that follow to the show.
        /// </summary>
        public virtual ICollection<User> Followers { get; set; }

        /// <summary>
        /// Gets or sets the updates.
        /// </summary>
        public virtual ICollection<Update> Updates { get; set; }
    }
}