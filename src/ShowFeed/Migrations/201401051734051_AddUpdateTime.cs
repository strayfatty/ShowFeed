namespace ShowFeed.Migrations
{
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Database migration that introduces the update time.
    /// </summary>
    public partial class AddUpdateTime : DbMigration
    {
        /// <summary>
        /// Operations to be performed during the upgrade process.
        /// </summary>
        public override void Up()
        {
            this.AddColumn("dbo.Update", "UpdateTime", c => c.Int(nullable: false));
        }

        /// <summary>
        /// Operations to be performed during the downgrade process.
        /// </summary>
        public override void Down()
        {
            this.DropColumn("dbo.Update", "UpdateTime");
        }
    }
}
