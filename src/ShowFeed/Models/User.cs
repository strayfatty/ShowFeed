namespace ShowFeed.Models
{
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
    }
}