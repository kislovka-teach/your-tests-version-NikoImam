using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VariantOne.Entities;

namespace VariantOne.Configurations.EntityConfigs
{
    public class UserEntityConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(u => u.Username).IsUnique();
            builder.Property(u => u.Id).ValueGeneratedOnAdd();
        }
    }
}
