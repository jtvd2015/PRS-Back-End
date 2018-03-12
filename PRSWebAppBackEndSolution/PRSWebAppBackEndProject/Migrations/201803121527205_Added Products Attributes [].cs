namespace PRSWebAppBackEndProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedProductsAttributes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "VendorPartNumber", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Products", "Unit", c => c.String(nullable: false));
            AlterColumn("dbo.Vendors", "PostalCode", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vendors", "PostalCode", c => c.String());
            AlterColumn("dbo.Products", "Unit", c => c.String());
            AlterColumn("dbo.Products", "Name", c => c.String());
            AlterColumn("dbo.Products", "VendorPartNumber", c => c.String());
        }
    }
}
