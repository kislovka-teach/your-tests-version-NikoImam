using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VariantOne.Entities;

namespace VariantOne.Configurations.EntityConfigs
{
    public class ReviewEntityConfig : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
        }
    }
}
