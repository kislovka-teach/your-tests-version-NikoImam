using Microsoft.EntityFrameworkCore;
using VariantOne.Entities;
using VariantOne.Extensioins;

namespace VariantOne.DbContexts
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Tea> Teas => Set<Tea>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<Review> Reviews => Set<Review>();
        public DbSet<User> Users => Set<User>();

        public ApplicationContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurations();

            modelBuilder.Entity<Tea>()
                .HasData(
                    new Tea { Id = 1, Name = "Майя", TeaType = TeaType.Black, Country = "Шри-Ланка" },
                    new Tea { Id = 2, Name = "Цейлон", TeaType = TeaType.Green, Country = "Казахстан" }
                );

            modelBuilder.Entity<Product>()
                .HasData(
                    new Product
                    {
                        Id = 1,
                        TeaId = 1,
                        QuantityInStock = 1000,
                        Volume = 100,
                        PackagingType = PackagingType.Bags,
                        Price = 450,
                        Manufacturer = "OOO Chai"
                    },
                    new Product
                    {
                        Id = 2,
                        TeaId = 2,
                        QuantityInStock = 550,
                        Volume = 500,
                        PackagingType = PackagingType.Weight,
                        Price = 1700,
                        Manufacturer = "Bjenxci"
                    }
                );

            modelBuilder.Entity<Order>()
                .HasData(
                    new Order
                    {
                        Id = 1,
                        UserId = 1,
                        ProductId = 1,
                        Count = 2,
                        TotalPrice = 900,
                        Status = Status.Preparing
                    },
                    new Order
                    {
                        Id = 2,
                        UserId = 1,
                        ProductId = 1,
                        Count = 3,
                        TotalPrice = 1250,
                        Status = Status.AwaitPayment
                    }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
