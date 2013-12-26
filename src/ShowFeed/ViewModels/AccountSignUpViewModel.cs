namespace ShowFeed.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The account sign up view model.
    /// </summary>
    public class AccountSignUpViewModel
    {
        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        [Required]
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the confirm password.
        /// </summary>
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}