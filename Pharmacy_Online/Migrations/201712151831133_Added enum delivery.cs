namespace Pharmacy_Online.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedenumdelivery : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Order", "Delivery", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Order", "Delivery");
        }
    }
}
