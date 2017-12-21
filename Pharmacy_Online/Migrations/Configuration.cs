using Pharmacy_Online.Data_Access_Layer;

namespace Pharmacy_Online.Migrations
{
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<Pharmacy_Online.Data_Access_Layer.ProductsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Pharmacy_Online.Data_Access_Layer.ProductsContext";
        }

        protected override void Seed(Pharmacy_Online.Data_Access_Layer.ProductsContext context)
        {

            ProductsInitializer.SeedProductsData(context);
            ProductsInitializer.SeedUsers(context);
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
