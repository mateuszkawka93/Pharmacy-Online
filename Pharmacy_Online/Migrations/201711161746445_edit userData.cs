namespace Pharmacy_Online.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edituserData : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Order", "Address", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "UserData_PostCode", c => c.String());
            DropColumn("dbo.Order", "Street");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Order", "Street", c => c.String(nullable: false));
            DropColumn("dbo.AspNetUsers", "UserData_PostCode");
            DropColumn("dbo.Order", "Address");
        }
    }
}
