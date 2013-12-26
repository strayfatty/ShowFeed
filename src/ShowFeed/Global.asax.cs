﻿namespace ShowFeed
{
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    using ShowFeed.App_Start;

    /// <summary>
    /// The MVC application class.
    /// </summary>
    public class MvcApplication : HttpApplication
    {
        /// <summary>
        /// The application start event handler.
        /// </summary>
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            DatabaseConfig.Initialize();
        }
    }
}
