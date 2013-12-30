﻿namespace ShowFeed.App_Start
{
    using System.Web.Http;

    /// <summary>
    /// The web API configuration class.
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// Registers all API routes.
        /// </summary>
        /// <param name="routes">The route collection.</param>
        public static void RegisterRoutes(HttpRouteCollection routes)
        {
            routes.MapHttpRoute("api/tvshows", "api/tvshows/{id}", new { controller = "TvShowsApi", id = RouteParameter.Optional });
        }
    }
}