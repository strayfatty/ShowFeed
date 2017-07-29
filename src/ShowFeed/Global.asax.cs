namespace ShowFeed
{
    using System;
    using System.Web;
    using System.Web.Http;

    using ShowFeed.Server;

    /// <summary>
    /// The global application class.
    /// </summary>
    public class Global : HttpApplication
    {
        /// <summary>
        /// The application start event handler.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        protected void Application_Start(object sender, EventArgs e)
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}