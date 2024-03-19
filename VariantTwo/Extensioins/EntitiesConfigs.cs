using Microsoft.EntityFrameworkCore;
using VariantTwo.Configurations.EntityConfigs;

namespace VariantTwo.Extensioins
{
    public static class EntitiesConfigs
    {
        public static void ApplyConfigurations(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CarModelEntityConfig());
            modelBuilder.ApplyConfiguration(new CarEntityConfig());
            modelBuilder.ApplyConfiguration(new ArticleEntityConfig());
            modelBuilder.ApplyConfiguration(new CommentEntityConfig());
            modelBuilder.ApplyConfiguration(new UserEntityConfig());
        }
    }
}
