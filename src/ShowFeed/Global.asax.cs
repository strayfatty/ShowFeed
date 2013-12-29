namespace ShowFeed
{
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    using ShowFeed.App_Start;

    using SimpleInjector;
    using SimpleInjector.Integration.Web.Mvc;

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

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            DatabaseConfig.Initialize();

            var container = new Container();
            SimpleInjectorConfig.RegisterDependencies(container);
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}
