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
            routes.MapHttpRoute("api/calendar", "api/calendar", new { controller = "CalendarApi" });
            routes.MapHttpRoute("api/series", "api/series/{id}", new { controller = "SeriesApi", id = RouteParameter.Optional });
            routes.MapHttpRoute("api/episodes", "api/episodes/{id}", new { controller = "EpisodesApi", id = RouteParameter.Optional });
        }
    }
}