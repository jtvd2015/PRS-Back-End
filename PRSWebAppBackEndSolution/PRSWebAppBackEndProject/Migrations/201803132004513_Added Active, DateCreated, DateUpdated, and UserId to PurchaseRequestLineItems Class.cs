namespace PRSWebAppBackEndProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedActiveDateCreatedDateUpdatedandUserIdtoPurchaseRequestLineItemsClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PurchaseRequestLineItems", "Active", c => c.Boolean(nullable: false));
            AddColumn("dbo.PurchaseRequestLineItems", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.PurchaseRequestLineItems", "DateUpdated", c => c.DateTime());
            AddColumn("dbo.PurchaseRequestLineItems", "UserId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PurchaseRequestLineItems", "UserId");
            DropColumn("dbo.PurchaseRequestLineItems", "DateUpdated");
            DropColumn("dbo.PurchaseRequestLineItems", "DateCreated");
            DropColumn("dbo.PurchaseRequestLineItems", "Active");
        }
    }
}
