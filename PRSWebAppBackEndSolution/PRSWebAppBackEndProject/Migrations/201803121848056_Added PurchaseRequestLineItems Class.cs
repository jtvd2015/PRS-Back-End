namespace PRSWebAppBackEndProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPurchaseRequestLineItemsClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PurchaseRequestLineItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PurchaseRequestId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        products_Id = c.Int(),
                        purchaseRequests_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.products_Id)
                .ForeignKey("dbo.PurchaseRequests", t => t.purchaseRequests_Id)
                .Index(t => t.products_Id)
                .Index(t => t.purchaseRequests_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PurchaseRequestLineItems", "purchaseRequests_Id", "dbo.PurchaseRequests");
            DropForeignKey("dbo.PurchaseRequestLineItems", "products_Id", "dbo.Products");
            DropIndex("dbo.PurchaseRequestLineItems", new[] { "purchaseRequests_Id" });
            DropIndex("dbo.PurchaseRequestLineItems", new[] { "products_Id" });
            DropTable("dbo.PurchaseRequestLineItems");
        }
    }
}
