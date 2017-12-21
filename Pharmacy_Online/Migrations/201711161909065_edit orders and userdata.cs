namespace Pharmacy_Online.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editordersanduserdata : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Order", name: "ApplicationUser_Id", newName: "UserId");
            RenameIndex(table: "dbo.Order", name: "IX_ApplicationUser_Id", newName: "IX_UserId");
            AlterColumn("dbo.Order", "PostCode", c => c.String(nullable: false, maxLength: 6));
            AlterColumn("dbo.Order", "Phone", c => c.String(nullable: false));
            AlterColumn("dbo.Order", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Order", "Email", c => c.String());
            AlterColumn("dbo.Order", "Phone", c => c.String());
            AlterColumn("dbo.Order", "PostCode", c => c.String(nullable: false));
            RenameIndex(table: "dbo.Order", name: "IX_UserId", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.Order", name: "UserId", newName: "ApplicationUser_Id");
        }
    }
}
