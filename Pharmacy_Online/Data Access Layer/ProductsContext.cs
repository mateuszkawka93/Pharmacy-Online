using Microsoft.AspNet.Identity.EntityFramework;
using Pharmacy_Online.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Pharmacy_Online.Data_Access_Layer
{
    public class ProductsContext : IdentityDbContext<ApplicationUser>
    {
        public ProductsContext() : base("ProductsContext")
        {
            
        }

        static ProductsContext()
        {
            Database.SetInitializer(new ProductsInitializer());
        }

        public static ProductsContext Create()
        {
            return new ProductsContext();
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderPosition> OrderPositions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}