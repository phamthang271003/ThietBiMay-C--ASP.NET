namespace Đồ_án_lập_trình_web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcolumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.News", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Posts", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "IsActive");
            DropColumn("dbo.News", "IsActive");
        }
    }
}
