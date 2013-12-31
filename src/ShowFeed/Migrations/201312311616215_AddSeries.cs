namespace ShowFeed.Migrations
{
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Database migration that adds the series.
    /// </summary>
    public partial class AddSeries : DbMigration
    {
        /// <summary>
        /// Operations to be performed during the upgrade process.
        /// </summary>
        public override void Up()
        {
            this.CreateTable(
                "dbo.Series",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    SeriesId = c.Int(nullable: false),
                    ImdbId = c.String(),
                    Name = c.String(),
                    Description = c.String(),
                    BannerLink = c.String(),
                    FanArtLink = c.String(),
                    PosterLink = c.String(),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.SeriesId, unique: true);

            this.CreateTable(
                "dbo.Episode",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EpisodeId = c.Int(nullable: false),
                        SeasonNumber = c.Int(nullable: false),
                        EpisodeNumber = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        FirstAired = c.DateTime(),
                        ImageLink = c.String(),
                        Series_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Series", t => t.Series_Id,  cascadeDelete: true)
                .Index(t => t.Series_Id)
                .Index(t => t.EpisodeId);
            
            this.CreateTable(
                "dbo.UserSeries",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        Series_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Series_Id })
                .ForeignKey("dbo.User", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.Series", t => t.Series_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Series_Id);
            
            this.CreateTable(
                "dbo.UserEpisodes",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        Episode_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Episode_Id })
                .ForeignKey("dbo.User", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.Episode", t => t.Episode_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Episode_Id);
        }

        /// <summary>
        /// Operations to be performed during the downgrade process.
        /// </summary>
        public override void Down()
        {
            this.DropForeignKey("dbo.UserEpisodes", "Episode_Id", "dbo.Episode");
            this.DropForeignKey("dbo.UserEpisodes", "User_Id", "dbo.User");
            this.DropForeignKey("dbo.UserSeries", "Series_Id", "dbo.Series");
            this.DropForeignKey("dbo.UserSeries", "User_Id", "dbo.User");
            this.DropForeignKey("dbo.Episode", "Series_Id", "dbo.Series");
            this.DropIndex("dbo.UserEpisodes", new[] { "Episode_Id" });
            this.DropIndex("dbo.UserEpisodes", new[] { "User_Id" });
            this.DropIndex("dbo.UserSeries", new[] { "Series_Id" });
            this.DropIndex("dbo.UserSeries", new[] { "User_Id" });
            this.DropIndex("dbo.Episode", new[] { "EpisodeId" });
            this.DropIndex("dbo.Episode", new[] { "Series_Id" });
            this.DropIndex("dbo.Series", new[] { "SeriesId" });
            this.DropTable("dbo.UserEpisodes");
            this.DropTable("dbo.UserSeries");
            this.DropTable("dbo.Episode");
            this.DropTable("dbo.Series");
        }
    }
}
