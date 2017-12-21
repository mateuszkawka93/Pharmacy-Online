namespace Pharmacy_Online.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editordermodel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Order", "Comment", c => c.String(maxLength: 300));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Order", "Comment", c => c.String());
        }
    }
}
