namespace ShowFeed.Server
{
    using System;
    using System.Linq;

    using Serilog;
    using Serilog.Core;

    /// <summary>
    /// The logger configuration.
    /// </summary>
    public static class Logger
    {
        /// <summary>
        /// The logger instance.
        /// </summary>
        private static readonly ILogger Instance = new LoggerConfiguration()
            .ReadFrom.AppSettings()
            .CreateLogger();

        /// <summary>
        /// Create a logger that marks log events as being from the specified source type.
        /// </summary>
        /// <typeparam name="T">The source type.</typeparam>
        /// <returns>A logger that will enrich log events as specified.</returns>
        public static ILogger ForContext<T>()
        {
            return Instance.ForContext<T>();
        }

        /// <summary>
        /// Create a logger that marks log events as being from the specified source type.
        /// </summary>
        /// <param name="source">The source type.</param>
        /// <returns>A logger that will enrich log events as specified.</returns>
        public static ILogger ForContext(Type source)
        {
            if (source == null)
            {
                return Instance.ForContext(Enumerable.Empty<ILogEventEnricher>());
            }

            return Instance.ForContext(source);
        }
    }
}