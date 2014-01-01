namespace ShowFeed.App_Start
{
    using System.Web.Mvc;

    /// <summary>
    /// The filter configuration class..
    /// </summary>
    public static class FilterConfig
    {
        /// <summary>
        /// Registers the global filters.
        /// </summary>
        /// <param name="filters">The global filter collection.</param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuthorizeAttribute());
        }
    }
}