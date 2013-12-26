namespace ShowFeed.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The account sign up view model.
    /// </summary>
    public class AccountLogInViewModel
    {
        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        [Required]
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}