using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PadelStore.Data.Models;


namespace PadelStore.Data.Configuration
{
    public class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> entity)
        {


            entity.
                Property(p => p.Price)
                .HasPrecision(18, 2);
        }
    }
}
