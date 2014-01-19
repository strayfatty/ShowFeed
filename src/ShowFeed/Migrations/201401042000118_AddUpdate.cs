namespace ShowFeed.Migrations
{
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Database migration that introduces updates.
    /// </summary>
    public partial class AddUpdate : DbMigration
    {
        /// <summary>
        /// Operations to be performed during the upgrade process.
        /// </summary>
        public override void Up()
        {
            this.CreateTable(
                "dbo.Update",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Started = c.Int(nullable: false),
                        Finished = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);

            this.CreateTable(
                "dbo.UpdateSeries",
                c => new
                {
                    Update_Id = c.Int(nullable: false),
                    Series_Id = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.Update_Id, t.Series_Id })
                .ForeignKey("dbo.Update", t => t.Update_Id, cascadeDelete: true)
                .ForeignKey("dbo.Series", t => t.Series_Id, cascadeDelete: true)
                .Index(t => t.Update_Id)
                .Index(t => t.Series_Id);

            this.CreateTable(
                "dbo.UpdateEpisodes",
                c => new
                    {
                        Update_Id = c.Int(nullable: false),
                        Episode_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Update_Id, t.Episode_Id })
                .ForeignKey("dbo.Update", t => t.Update_Id, cascadeDelete: true)
                .ForeignKey("dbo.Episode", t => t.Episode_Id, cascadeDelete: true)
                .Index(t => t.Update_Id)
                .Index(t => t.Episode_Id);    
        }

        /// <summary>
        /// Operations to be performed during the downgrade process.
        /// </summary>
        public override void Down()
        {
            this.DropForeignKey("dbo.UpdateEpisodes", "Episode_Id", "dbo.Episode");
            this.DropForeignKey("dbo.UpdateEpisodes", "Update_Id", "dbo.Update");
            this.DropForeignKey("dbo.UpdateSeries", "Series_Id", "dbo.Series");
            this.DropForeignKey("dbo.UpdateSeries", "Update_Id", "dbo.Update");
            this.DropIndex("dbo.UpdateEpisodes", new[] { "Episode_Id" });
            this.DropIndex("dbo.UpdateEpisodes", new[] { "Update_Id" });
            this.DropIndex("dbo.UpdateSeries", new[] { "Series_Id" });
            this.DropIndex("dbo.UpdateSeries", new[] { "Update_Id" });
            this.DropTable("dbo.UpdateEpisodes");
            this.DropTable("dbo.UpdateSeries");
            this.DropTable("dbo.Update");
        }
    }
}
