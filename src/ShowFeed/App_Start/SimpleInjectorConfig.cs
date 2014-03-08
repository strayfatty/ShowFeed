namespace ShowFeed.App_Start
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Web;
    using System.Web.Http;
    using System.Web.Http.Dependencies;
    using System.Web.Mvc;

    using ShowFeed.Models;
    using ShowFeed.Services;
    using ShowFeed.Services.TheTvDb;

    using SimpleInjector;
    using SimpleInjector.Extensions.LifetimeScoping;
    using SimpleInjector.Integration.Web;
    using SimpleInjector.Integration.Web.Mvc;

    /// <summary>
    /// The simple injector configuration class.
    /// </summary>
    public static class SimpleInjectorConfig
    {
        /// <summary>
        /// Registers all dependencies with the simple injector.
        /// </summary>
        public static void RegisterDependencies()
        {
            var container = new Container();
            var hybridLifeStyle = Lifestyle.CreateHybrid(
                () => HttpContext.Current != null,
                new WebRequestLifestyle(),
                new LifetimeScopeLifestyle());

            container.RegisterMvcControllers(typeof(SimpleInjectorConfig).Assembly);
            container.RegisterMvcAttributeFilterProvider();

            container.Register<IDatabase, ShowFeedDatabase>(hybridLifeStyle);
            container.Register<ISeriesService, TheTvDbSeriesService>(hybridLifeStyle);

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new WebApiDependencyResolver(container);
        }

        /// <summary>
        /// The web API dependency resolver.
        /// </summary>
        public sealed class WebApiDependencyResolver : System.Web.Http.Dependencies.IDependencyResolver
        {
            /// <summary>
            /// The DI container.
            /// </summary>
            private readonly Container container;

            /// <summary>
            /// Initializes a new instance of the <see cref="WebApiDependencyResolver"/> class.
            /// </summary>
            /// <param name="container">The container.</param>
            public WebApiDependencyResolver(Container container)
            {
                this.container = container;
            }

            /// <summary>
            /// Starts a resolution scope.
            /// </summary>
            /// <returns>The dependency scope.</returns>
            [DebuggerStepThrough]
            public IDependencyScope BeginScope()
            {
                return this;
            }

            /// <summary>
            /// Retrieves a service from the scope.
            /// </summary>
            /// <param name="serviceType">The service to be retrieved.</param>
            /// <returns>The retrieved service.</returns>
            [DebuggerStepThrough]
            public object GetService(Type serviceType)
            {
                return ((IServiceProvider)this.container)
                    .GetService(serviceType);
            }

            /// <summary>
            /// Retrieves a collection of services from the scope.
            /// </summary>
            /// <param name="serviceType">The collection of services to be retrieved.</param>
            /// <returns>The retrieved collection of services.</returns>
            [DebuggerStepThrough]
            public IEnumerable<object> GetServices(Type serviceType)
            {
                return this.container.GetAllInstances(serviceType);
            }

            /// <summary>
            /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
            /// </summary>
            [DebuggerStepThrough]
            public void Dispose()
            {
            }
        }
    }
}