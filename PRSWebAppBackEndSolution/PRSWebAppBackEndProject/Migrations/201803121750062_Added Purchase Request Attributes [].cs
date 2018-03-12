namespace PRSWebAppBackEndProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPurchaseRequestAttributes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PurchaseRequests", "Description", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.PurchaseRequests", "Justification", c => c.String(nullable: false));
            AlterColumn("dbo.PurchaseRequests", "DeliveryMode", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.PurchaseRequests", "Status", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.PurchaseRequests", "ReasonForRejection", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PurchaseRequests", "ReasonForRejection", c => c.String());
            AlterColumn("dbo.PurchaseRequests", "Status", c => c.String());
            AlterColumn("dbo.PurchaseRequests", "DeliveryMode", c => c.String());
            AlterColumn("dbo.PurchaseRequests", "Justification", c => c.String());
            AlterColumn("dbo.PurchaseRequests", "Description", c => c.String());
        }
    }
}
