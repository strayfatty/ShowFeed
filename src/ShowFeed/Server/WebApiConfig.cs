namespace ShowFeed.Server
{
    using System.Web.Http;
    using System.Web.Http.ExceptionHandling;

    using Newtonsoft.Json.Converters;
    using Newtonsoft.Json.Serialization;

    using Serilog;

    /// <summary>
    /// The Web API configuration.
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// Registers the Web API configuration.
        /// </summary>
        /// <param name="config">The HTTP configuration.</param>
        public static void Register(HttpConfiguration config)
        {
            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            json.SerializerSettings.Converters.Add(new StringEnumConverter { CamelCaseText = true });

            config.MapHttpAttributeRoutes();

            config.Services.Add(typeof(IExceptionLogger), new SerilogExecptionLogger());
        }

        /// <summary>
        /// The serilog exception logger.
        /// </summary>
        private class SerilogExecptionLogger : ExceptionLogger
        {
            /// <summary>
            /// The logger.
            /// </summary>
            private readonly ILogger logger;

            /// <summary>
            /// Initializes a new instance of the <see cref="SerilogExecptionLogger"/> class.
            /// </summary>
            public SerilogExecptionLogger()
            {
                this.logger = Logger.ForContext<SerilogExecptionLogger>();
            }

            /// <summary>
            /// When overridden in a derived class, logs the exception synchronously.
            /// </summary>
            /// <param name="context">The exception logger context.</param>
            public override void Log(ExceptionLoggerContext context)
            {
                this.logger.Error(
                    context.Exception,
                    "Unhandled exception processing {0} for {1}",
                    context.Request.Method,
                    context.Request.RequestUri.PathAndQuery);
            }
        }
    }
}