namespace ShowFeed.App_Start
{
    using System.Web.Optimization;

    /// <summary>
    /// The bundle configuration class.
    /// </summary>
    public static class BundleConfig
    {
        /// <summary>
        /// Registers the bundles.
        /// </summary>
        /// <param name="bundles">The bundle collection.</param>
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/bootstrap-actionlinks.css",
                "~/Content/bs-sidebar.css",
                "~/Content/calendar.css"));

            bundles.Add(new ScriptBundle("~/Scripts/js").Include(
                "~/Scripts/jquery-2.0.3.js",
                "~/Scripts/underscore.js",
                "~/Scripts/bootstrap.js",
                "~/Scripts/calendar.js",
                "~/Scripts/custom.js"));

            ////Set EnableOptimizations to true to test bundles while debugging.
            ////BundleTable.EnableOptimizations = true;
        }
    }
}