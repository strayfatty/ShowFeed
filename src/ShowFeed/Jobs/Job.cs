namespace ShowFeed.Jobs
{
    using System;
    using System.Web;
    using System.Web.Caching;

    using ShowFeed.App_Start;

    /// <summary>
    /// The job.
    /// </summary>
    public static class Job
    {
        /// <summary>
        /// Queues a job for execution.
        /// </summary>
        /// <param name="job">The job.</param>
        /// <param name="delay">The delay.</param>
        public static void Queue(IJob job, TimeSpan delay)
        {
            HttpRuntime.Cache.Add(
                job.GetType().ToString(),
                job,
                null,
                Cache.NoAbsoluteExpiration,
                delay,
                CacheItemPriority.Normal,
                Callback);
        }

        /// <summary>
        /// Queues a recurring job for execution.
        /// </summary>
        /// <param name="job">
        /// The job.
        /// </param>
        public static void Queue(IRecurringJob job)
        {
            Queue(job, job.Interval);
        }

        /// <summary>
        /// Callback triggered when a job should be executed.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="reason">The reason.</param>
        private static void Callback(string key, object value, CacheItemRemovedReason reason)
        {
            if (reason == CacheItemRemovedReason.Expired)
            {
                var job = (IJob)value;

                using (SimpleInjectorConfig.BeginLifetimeScope())
                {
                    job.Run();
                }

                var recurringJob = (IRecurringJob)value;
                if (recurringJob != null)
                {
                    Queue(recurringJob);
                }
            }
        }
    }
}
