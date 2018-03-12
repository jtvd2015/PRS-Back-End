namespace PRSWebAppBackEndProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class purchaseRequeststoPurchaseRequests : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.PurchaseRequestLineItems", new[] { "products_Id" });
            DropIndex("dbo.PurchaseRequestLineItems", new[] { "purchaseRequests_Id" });
            CreateIndex("dbo.PurchaseRequestLineItems", "Products_Id");
            CreateIndex("dbo.PurchaseRequestLineItems", "PurchaseRequests_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.PurchaseRequestLineItems", new[] { "PurchaseRequests_Id" });
            DropIndex("dbo.PurchaseRequestLineItems", new[] { "Products_Id" });
            CreateIndex("dbo.PurchaseRequestLineItems", "purchaseRequests_Id");
            CreateIndex("dbo.PurchaseRequestLineItems", "products_Id");
        }
    }
}
