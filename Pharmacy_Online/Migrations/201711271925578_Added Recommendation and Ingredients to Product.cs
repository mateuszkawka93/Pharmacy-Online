namespace Pharmacy_Online.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRecommendationandIngredientstoProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "Recommendation", c => c.String());
            AddColumn("dbo.Product", "Ingredients", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "Ingredients");
            DropColumn("dbo.Product", "Recommendation");
        }
    }
}
