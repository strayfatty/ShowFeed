namespace ShowFeed.App_Start
{
    using System.Data.Entity;
    using System.Linq;

    using ShowFeed.Migrations;
    using ShowFeed.Models;

    using WebMatrix.WebData;

    /// <summary>
    /// The database configuration class.
    /// </summary>
    public static class DatabaseConfig
    {
        /// <summary>
        /// Initializes the database.
        /// </summary>
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ShowFeedDatabase, Configuration>());

            // One call into the database is required for the update to take place.
            var profiles = new ShowFeedDatabase().Set<User>().FirstOrDefault();

            WebSecurity.InitializeDatabaseConnection(ShowFeedDatabase.ConnectionStringName, "User", "Id", "Username", true);
        }
    }
}
