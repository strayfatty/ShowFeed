namespace ShowFeed
{
    using System;
    using System.Web;
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    using Newtonsoft.Json.Serialization;

    using ShowFeed.App_Start;

    using SimpleInjector;
    using SimpleInjector.Integration.Web.Mvc;

    using StackExchange.Profiling;

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
            MiniProfilerConfig.PreApplicationStartInitialization();

            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            WebApiConfig.RegisterRoutes(GlobalConfiguration.Configuration.Routes);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            DatabaseConfig.Initialize();
            AutoMapperConfig.RegisterMappings();
            SimpleInjectorConfig.RegisterDependencies();

            MiniProfilerConfig.PostApplicationStartInitialization();

            var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            json.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }

        /// <summary>
        /// The application begin request event handler.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The event arguments.</param>
        protected void Application_BeginRequest(object sender, EventArgs args)
        {
            MiniProfiler.Start();
        }

        /// <summary>
        /// The application end request event handler.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The event arguments.</param>
        protected void Application_EndRequest(object sender, EventArgs args)
        {
            MiniProfiler.Stop();
        }
    }
}
