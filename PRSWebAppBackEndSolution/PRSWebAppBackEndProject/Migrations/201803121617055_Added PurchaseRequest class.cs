namespace PRSWebAppBackEndProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPurchaseRequestclass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PurchaseRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Description = c.String(),
                        Justification = c.String(),
                        DeliveryMode = c.String(),
                        Status = c.String(),
                        Total = c.Decimal(nullable: false, precision: 10, scale: 2),
                        Active = c.Boolean(nullable: false),
                        ReasonForRejection = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        DateUpdated = c.DateTime(),
                        UpdatedByUser = c.Int(),
                        users_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.users_Id)
                .Index(t => t.users_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PurchaseRequests", "users_Id", "dbo.Users");
            DropIndex("dbo.PurchaseRequests", new[] { "users_Id" });
            DropTable("dbo.PurchaseRequests");
        }
    }
}
