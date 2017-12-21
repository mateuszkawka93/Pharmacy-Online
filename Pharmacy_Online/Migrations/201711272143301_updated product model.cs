namespace Pharmacy_Online.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedproductmodel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Product", "Name", c => c.String(nullable: false, maxLength: 150));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Product", "Name", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
