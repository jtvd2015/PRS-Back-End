namespace PRSWebAppBackEndProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedVendorClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Vendors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        PostalCode = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        IsPreApproved = c.Boolean(nullable: false),
                        Active = c.Boolean(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateUpdated = c.DateTime(),
                        UserId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Vendors");
        }
    }
}
