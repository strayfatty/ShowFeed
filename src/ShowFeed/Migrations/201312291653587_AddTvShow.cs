namespace ShowFeed.Migrations
{
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Database migration that adds the TV show.
    /// </summary>
    public partial class AddTvShow : DbMigration
    {
        /// <summary>
        /// Operations to be performed during the upgrade process.
        /// </summary>
        public override void Up()
        {
            this.CreateTable(
                "dbo.TvShow",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    SourceId = c.Int(nullable: false),
                    SourceLink = c.String(),
                    SourceImageLink = c.String(),
                    Name = c.String(),
                    Description = c.String(),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.SourceId, unique: true);

            this.CreateTable(
                "dbo.TvEpisode",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SourceLink = c.String(),
                        SourceImageLink = c.String(),
                        Season = c.Int(nullable: false),
                        Index = c.Int(nullable: false),
                        Title = c.String(),
                        Summary = c.String(),
                        AirDate = c.DateTime(),
                        Show_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TvShow", t => t.Show_Id, cascadeDelete: true)
                .Index(t => t.Show_Id);

            this.CreateTable(
                "dbo.UserTvShows",
                c => new
                {
                    User_Id = c.Int(nullable: false),
                    TvShow_Id = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.User_Id, t.TvShow_Id })
                .ForeignKey("dbo.User", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.TvShow", t => t.TvShow_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.TvShow_Id);

            this.CreateTable(
                "dbo.UserTvEpisodes",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        TvEpisode_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.TvEpisode_Id })
                .ForeignKey("dbo.User", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.TvEpisode", t => t.TvEpisode_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.TvEpisode_Id);
        }

        /// <summary>
        /// Operations to be performed during the downgrade process.
        /// </summary>
        public override void Down()
        {
            this.DropForeignKey("dbo.UserTvEpisodes", "TvEpisode_Id", "dbo.TvEpisode");
            this.DropForeignKey("dbo.UserTvEpisodes", "User_Id", "dbo.User");
            this.DropForeignKey("dbo.UserTvShows", "TvShow_Id", "dbo.TvShow");
            this.DropForeignKey("dbo.UserTvShows", "User_Id", "dbo.User");
            this.DropForeignKey("dbo.TvEpisode", "Show_Id", "dbo.TvShow");
            this.DropIndex("dbo.UserTvEpisodes", new[] { "TvEpisode_Id" });
            this.DropIndex("dbo.UserTvEpisodes", new[] { "User_Id" });
            this.DropIndex("dbo.UserTvShows", new[] { "TvShow_Id" });
            this.DropIndex("dbo.UserTvShows", new[] { "User_Id" });
            this.DropIndex("dbo.TvEpisode", new[] { "Show_Id" });
            this.DropIndex("dbo.TvShow", new[] { "SourceId" });
            this.DropTable("dbo.UserTvEpisodes");
            this.DropTable("dbo.UserTvShows");
            this.DropTable("dbo.TvEpisode");
            this.DropTable("dbo.TvShow");
        }
    }
}
