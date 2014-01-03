namespace ShowFeed.Migrations
{
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Database migration that introduces a max length for several texts.
    /// </summary>
    public partial class AddMaxLength : DbMigration
    {
        /// <summary>
        /// Operations to be performed during the upgrade process.
        /// </summary>
        public override void Up()
        {
            this.AlterColumn("dbo.Episode", "Name", c => c.String(maxLength: 255));
            this.AlterColumn("dbo.Episode", "ImageLink", c => c.String(maxLength: 255));
            this.AlterColumn("dbo.Series", "ImdbId", c => c.String(maxLength: 25));
            this.AlterColumn("dbo.Series", "Name", c => c.String(maxLength: 255));
            this.AlterColumn("dbo.Series", "BannerLink", c => c.String(maxLength: 255));
            this.AlterColumn("dbo.Series", "FanArtLink", c => c.String(maxLength: 255));
            this.AlterColumn("dbo.Series", "PosterLink", c => c.String(maxLength: 255));
            this.AlterColumn("dbo.User", "Username", c => c.String(maxLength: 25));
            this.AlterColumn("dbo.User", "Email", c => c.String(maxLength: 255));
        }

        /// <summary>
        /// Operations to be performed during the downgrade process.
        /// </summary>
        public override void Down()
        {
            this.AlterColumn("dbo.User", "Email", c => c.String());
            this.AlterColumn("dbo.User", "Username", c => c.String());
            this.AlterColumn("dbo.Series", "PosterLink", c => c.String());
            this.AlterColumn("dbo.Series", "FanArtLink", c => c.String());
            this.AlterColumn("dbo.Series", "BannerLink", c => c.String());
            this.AlterColumn("dbo.Series", "Name", c => c.String());
            this.AlterColumn("dbo.Series", "ImdbId", c => c.String());
            this.AlterColumn("dbo.Episode", "ImageLink", c => c.String());
            this.AlterColumn("dbo.Episode", "Name", c => c.String());
        }
    }
}
