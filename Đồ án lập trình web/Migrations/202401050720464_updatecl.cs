namespace Đồ_án_lập_trình_web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatecl : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.News", "Title", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Posts", "Title", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Posts", "Alias", c => c.String(maxLength: 150));
            AlterColumn("dbo.Posts", "Image", c => c.String(maxLength: 250));
            AlterColumn("dbo.Posts", "SeoTittle", c => c.String(maxLength: 250));
            AlterColumn("dbo.Posts", "SeoKeywords", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Posts", "SeoKeywords", c => c.String());
            AlterColumn("dbo.Posts", "SeoTittle", c => c.String());
            AlterColumn("dbo.Posts", "Image", c => c.String());
            AlterColumn("dbo.Posts", "Alias", c => c.String());
            AlterColumn("dbo.Posts", "Title", c => c.String());
            AlterColumn("dbo.News", "Title", c => c.String());
        }
    }
}
