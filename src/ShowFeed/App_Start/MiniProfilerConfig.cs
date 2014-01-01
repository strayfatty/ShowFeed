﻿namespace ShowFeed.App_Start
{
    using System.Linq;
    using System.Web.Mvc;

    using StackExchange.Profiling;
    using StackExchange.Profiling.MVCHelpers;
    using StackExchange.Profiling.SqlFormatters;

    /// <summary>
    /// The mini profiler configuration class.
    /// </summary>
    public static class MiniProfilerConfig
    {
        /// <summary>
        /// The pre application start initialization.
        /// </summary>
        public static void PreApplicationStartInitialization()
        {
            MiniProfiler.Settings.SqlFormatter = new SqlServerFormatter();

            // TODO: EF6 profiling, once miniprofiler supports it
            ////MiniProfilerEF.Initialize();

            GlobalFilters.Filters.Add(new ProfilingActionFilter());
        }

        /// <summary>
        /// The post application start initialization.
        /// </summary>
        public static void PostApplicationStartInitialization()
        {
            // Intercept ViewEngines to profile all partial views and regular views.
            // If you prefer to insert your profiling blocks manually you can comment this out
            var viewEngines = ViewEngines.Engines.ToList();
            ViewEngines.Engines.Clear();
            foreach (var viewEngine in viewEngines)
            {
                ViewEngines.Engines.Add(new ProfilingViewEngine(viewEngine));
            }
        }
    }
}