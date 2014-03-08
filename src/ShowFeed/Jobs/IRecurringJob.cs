namespace ShowFeed.Jobs
{
    using System;

    /// <summary>
    /// The interface for recurring jobs.
    /// </summary>
    public interface IRecurringJob : IJob
    {
        /// <summary>
        /// Gets the interval.
        /// </summary>
        TimeSpan Interval { get; }
    }
}
