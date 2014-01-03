namespace ShowFeed.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// The user class.
    /// </summary>
    [Table("User")]
    public class User : Entity
    {
        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        [MaxLength(25)]
        public virtual string Username { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        [MaxLength(255)]
        public virtual string Email { get; set; }

        /// <summary>
        /// Gets or sets the series that the user follows.
        /// </summary>
        public virtual ICollection<Series> FollowedSeries { get; set; }

        /// <summary>
        /// Gets or sets the episodes the user has viewed.
        /// </summary>
        public virtual ICollection<Episode> ViewedEpisodes { get; set; }
    }
}