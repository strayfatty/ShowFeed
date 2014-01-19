namespace ShowFeed.Extensions
{
    using System.Web.Mvc;

    /// <summary>
    /// The url helper extensions.
    /// </summary>
    public static class UrlHelperExtensions
    {
        /// <summary>
        /// Gets route class.
        /// </summary>
        /// <param name="helper">The url helper.</param>
        /// <param name="routeName">The route name.</param>
        /// <returns><c>active</c> if the route is the current route, <c>string.Empty</c> otherwise.</returns>
        public static string RouteClass(this UrlHelper helper, string routeName)
        {
            return helper.IsCurrentRoute(routeName) ? "active" : string.Empty;
        }

        /// <summary>
        /// Gets a value indicating weather a route is the current route.
        /// </summary>
        /// <param name="helper">The url helper.</param>
        /// <param name="routeName">The route name.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public static bool IsCurrentRoute(this UrlHelper helper, string routeName)
        {
            var actionName = (string)helper.RequestContext.RouteData.Values["action"];
            var controllerName = (string)helper.RequestContext.RouteData.Values["controller"];

            var routeUrl = helper.RouteUrl(routeName);
            var actionUrl = helper.Action(actionName, controllerName);

            return routeUrl.Equals(actionUrl);
        }
    }
}