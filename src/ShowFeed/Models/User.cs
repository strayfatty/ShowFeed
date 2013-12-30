namespace ShowFeed.Models
{
    using System.Collections.Generic;
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
        public virtual string Username { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        public virtual string Email { get; set; }

        /// <summary>
        /// Gets or sets the TV shows that the user follows.
        /// </summary>
        public virtual ICollection<TvShow> TvShowsFollowing { get; set; }

        /// <summary>
        /// Gets or sets the TV episodes the user has viewed.
        /// </summary>
        public virtual ICollection<TvEpisode> TvEpisodesViewed { get; set; }
    }
}