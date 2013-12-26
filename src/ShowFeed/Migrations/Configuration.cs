namespace ShowFeed.Migrations
{
    using System.Data.Entity.Migrations;

    using ShowFeed.Models;

    /// <summary>
    /// The database migration configuration.
    /// </summary>
    internal sealed class Configuration : DbMigrationsConfiguration<ShowFeedDatabase>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Configuration"/> class.
        /// </summary>
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
        }

        /// <summary>
        /// Runs after upgrading to the latest migration to allow seed data to be updated.
        /// </summary>
        /// <param name="context">Context to be used for updating seed data. </param>
        protected override void Seed(ShowFeedDatabase context)
        {
        }
    }
}
