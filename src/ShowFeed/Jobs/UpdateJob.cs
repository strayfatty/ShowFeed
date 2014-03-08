namespace ShowFeed.Jobs
{
    using System;

    /// <summary>
    /// The update job.
    /// </summary>
    public class UpdateJob : IRecurringJob
    {
        /// <summary>
        /// Gets the interval.
        /// </summary>
        public TimeSpan Interval
        {
            get
            {
                // TODO read delay from config
                return new TimeSpan(0, 0, 10);
            }
        }

        /// <summary>
        /// Runs the job.
        /// </summary>
        public void Run()
        {
            // TODO
        }
    }
}
