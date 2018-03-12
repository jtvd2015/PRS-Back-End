namespace PRSWebAppBackEndProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedVendorAttributes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vendors", "Code", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Vendors", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Vendors", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.Vendors", "City", c => c.String(nullable: false));
            AlterColumn("dbo.Vendors", "State", c => c.String(nullable: false, maxLength: 2));
            AlterColumn("dbo.Vendors", "Phone", c => c.String(nullable: false, maxLength: 12));
            AlterColumn("dbo.Vendors", "Email", c => c.String(nullable: false, maxLength: 75));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vendors", "Email", c => c.String());
            AlterColumn("dbo.Vendors", "Phone", c => c.String());
            AlterColumn("dbo.Vendors", "State", c => c.String());
            AlterColumn("dbo.Vendors", "City", c => c.String());
            AlterColumn("dbo.Vendors", "Address", c => c.String());
            AlterColumn("dbo.Vendors", "Name", c => c.String());
            AlterColumn("dbo.Vendors", "Code", c => c.String());
        }
    }
}
