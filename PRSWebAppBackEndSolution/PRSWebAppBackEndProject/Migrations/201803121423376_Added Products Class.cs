namespace PRSWebAppBackEndProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedProductsClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VendorId = c.Int(nullable: false),
                        VendorPartNumber = c.String(),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 10, scale: 2),
                        Unit = c.String(),
                        Photopath = c.String(),
                        Active = c.Boolean(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateUpdated = c.DateTime(),
                        UserId = c.Int(),
                        vendors_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Vendors", t => t.vendors_Id)
                .Index(t => t.vendors_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "vendors_Id", "dbo.Vendors");
            DropIndex("dbo.Products", new[] { "vendors_Id" });
            DropTable("dbo.Products");
        }
    }
}
