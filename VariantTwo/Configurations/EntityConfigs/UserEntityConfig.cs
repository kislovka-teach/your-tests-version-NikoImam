using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VariantTwo.Entities;

namespace VariantTwo.Configurations.EntityConfigs
{
    public class UserEntityConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(u => u.Username).IsUnique();
            builder.Property(u => u.Id).ValueGeneratedOnAdd();
            builder.HasMany(u => u.Cars).WithOne(c => c.Owner).HasForeignKey(c => c.OwnerId);
        }
    }
}
