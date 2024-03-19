using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VariantOne.Entities;

namespace VariantOne.Configurations.EntityConfigs
{
    public class TeaEntityConfig : IEntityTypeConfiguration<Tea>
    {
        public void Configure(EntityTypeBuilder<Tea> builder)
        {
            builder.HasIndex(t => t.Name).IsUnique();
        }
    }
}
