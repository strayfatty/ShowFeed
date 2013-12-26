namespace ShowFeed.Controllers
{
    using System.Web.Mvc;
    using System.Web.Security;

    using ShowFeed.Models;
    using ShowFeed.ViewModels;

    using WebMatrix.WebData;

    /// <summary>
    /// The account controller.
    /// </summary>
    public class AccountController : Controller
    {
        /// <summary>
        /// The login view.
        /// </summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        [HttpGet]
        [AllowAnonymous]
        public ActionResult LogIn()
        {
            return this.View(new AccountLogInViewModel());
        }

        /// <summary>
        /// The login action.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        [HttpPost]
        [AllowAnonymous]
        public ActionResult LogIn(AccountLogInViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                if (WebSecurity.Login(model.Username, model.Password))
                {
                    return this.RedirectToRoute("home");
                }

                this.ModelState.AddModelError(string.Empty, "Username and password did not match.");
            }

            return this.View(model);
        }

        /// <summary>
        /// The logout action.
        /// </summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        [HttpGet]
        public ActionResult LogOut()
        {
            WebSecurity.Logout();
            return this.RedirectToRoute("login");
        }

        /// <summary>
        /// The sign up view.
        /// </summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        [HttpGet]
        [AllowAnonymous]
        public ActionResult SignUp()
        {
            return this.View(new AccountSignUpViewModel());
        }

        /// <summary>
        /// The sign up action.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        [HttpPost]
        [AllowAnonymous]
        public ActionResult SignUp(AccountSignUpViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                try
                {
                    var propertyValues = new { Email = model.Email };
                    WebSecurity.CreateUserAndAccount(model.Username, model.Password, propertyValues);
                    WebSecurity.Login(model.Username, model.Password);

                    return this.RedirectToRoute("home");
                }
                catch (MembershipCreateUserException e)
                {
                    this.ModelState.AddModelError(string.Empty, e.Message);
                }
            }

            return this.View(model);
        }
    }
}