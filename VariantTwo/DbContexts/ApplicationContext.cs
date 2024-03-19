using Microsoft.EntityFrameworkCore;
using VariantTwo.Entities;
using VariantTwo.Extensioins;

namespace VariantTwo.DbContexts
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<CarModel> CarModels => Set<CarModel>();
        public DbSet<Car> Cars => Set<Car>();
        public DbSet<Article> Articles => Set<Article>();
        public DbSet<Comment> Comments => Set<Comment>();

        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarModel>()
                .HasData(
                    new CarModel { Brand = "Ford", Model = "Taurus", Id = 1},
                    new CarModel { Brand = "GAZ", Model = "3102", Id = 2},
                    new CarModel { Brand = "Toyota", Model = "Crown", Id = 3}
                );

            modelBuilder.Entity<Car>()
                .HasData(
                    new Car { CarModelId = 2, Id = 1, HorsePowers = 130, Color = "White", Year = 2003, PowerPlant = 0, OwnerId = 1},
                    new Car { CarModelId = 3, Id = 2, HorsePowers = 210, Color = "Silver", Year = 1994, PowerPlant = 0, OwnerId = 1}
                );

            modelBuilder.Entity<Article>()
                .HasData(
                    new Article
                    {
                        AuthorId = 1,
                        CarId = 1,
                        Id = 1,
                        PublishDate = DateOnly.FromDateTime(DateTime.UtcNow),
                        Rating = 0,
                        Title = "Ремонт хрома",
                        Text = "KDjnvfkdnjvnjfedvkjnfdkvlnljrsdvlanfvlaeh aei ufhae",
                        Topic = "Ремонт"
                    }
                );

            modelBuilder.Entity<Comment>()
                .HasData(
                    new Comment { ArticleId = 1, Text = "Норм", UserId = 1, Id = 1}
                );

            modelBuilder.ApplyConfigurations();
            base.OnModelCreating(modelBuilder);
        }
    }
}
