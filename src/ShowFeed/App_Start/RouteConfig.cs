﻿namespace ShowFeed.App_Start
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

            routes.MapRoute("home", "home", new { controller = "Home", action = "Index" });
        }
    }
}
