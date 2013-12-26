namespace ShowFeed.App_Start
{
    using ShowFeed.Models;

    using SimpleInjector;
    using SimpleInjector.Integration.Web;

    /// <summary>
    /// The simple injector configuration class.
    /// </summary>
    public static class SimpleInjectorConfig
    {
        /// <summary>
        /// Registers all dependencies with the simple injector.
        /// </summary>
        /// <param name="container">The container.</param>
        public static void RegisterDependencies(Container container)
        {
            container.RegisterMvcControllers(typeof(SimpleInjectorConfig).Assembly);
            container.RegisterMvcAttributeFilterProvider();

            container.Register<IDatabase, ShowFeedDatabase>(new WebRequestLifestyle());

            container.Verify();
        }
    }
}