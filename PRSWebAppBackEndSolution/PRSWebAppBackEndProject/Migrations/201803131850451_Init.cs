namespace PRSWebAppBackEndProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Products", new[] { "vendors_Id" });
            CreateIndex("dbo.Products", "Vendors_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Products", new[] { "Vendors_Id" });
            CreateIndex("dbo.Products", "vendors_Id");
        }
    }
}
