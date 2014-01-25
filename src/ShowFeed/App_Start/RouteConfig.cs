namespace ShowFeed.App_Start
{
    using System.Web.Mvc;
    using System.Web.Routing;

    /// <summary>
    /// The route configuration class.
    /// </summary>
    public static class RouteConfig
    {
        /// <summary>
        /// Registers all routes.
        /// </summary>
        /// <param name="routes">The route collection.</param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("login", "login", new { controller = "Account", action = "LogIn" });
            routes.MapRoute("logout", "logout", new { controller = "Account", action = "LogOut" });
            routes.MapRoute("signup", "signup", new { controller = "Account", action = "SignUp" });

            routes.MapRoute("calendar/day", "calendar/{year}/{month}/{day}", new { controller = "Calendar", action = "Day" });
            routes.MapRoute("calendar/month", "calendar/{year}/{month}", new { controller = "Calendar", action = "Month" });
            routes.MapRoute("calendar", "calendar", new { controller = "Calendar", action = "Index" });
            
            routes.MapRoute("home", string.Empty, new { controller = "Home", action = "Index" });
            routes.MapRoute("following", "following", new { controller = "Home", action = "Following" });
            routes.MapRoute("searchseries", "searchseries", new { controller = "Home", action = "SearchSeries" });

            routes.MapRoute("series/details", "series/{id}", new { controller = "Series", action = "Details" });
            routes.MapRoute("series", "series", new { controller = "Series", action = "Index" });

            routes.MapRoute("updates", "updates", new { controller = "Updates", action = "Index" });
            routes.MapRoute("updates/new", "updates/new", new { controller = "Updates", action = "New" });
        }
    }
}
