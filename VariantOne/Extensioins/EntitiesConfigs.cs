using Microsoft.EntityFrameworkCore;
using VariantOne.Configurations.EntityConfigs;

namespace VariantOne.Extensioins
{
    public static class EntitiesConfigs
    {
        public static void ApplyConfigurations(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserEntityConfig());
            modelBuilder.ApplyConfiguration(new TeaEntityConfig());
            modelBuilder.ApplyConfiguration(new ProductEntityConfig());
            modelBuilder.ApplyConfiguration(new OrderEntityConfig());
            modelBuilder.ApplyConfiguration(new ReviewEntityConfig());
        }
    }
}
