

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PadelStore.Data.Models;

namespace PadelStore.Data.Configuration
{
    public class BrandEntityConfiguration : IEntityTypeConfiguration<Brand>
    {
        private readonly Brand[] brands = new Brand[]
           {
                new Brand
                {
                    Id = Guid.Parse("b2c5d88a-b33e-47f6-bbf2-a1605f77857b"),
                    BrandName = "Nike"
                },
                 new Brand
                {
                    Id = Guid.Parse("eb8608d9-3afc-4de5-b335-2635a1d3d584"),
                    BrandName = "Adidas"
                },
                 new Brand
                {
                    Id = Guid.Parse("6c041405-fc59-446d-abf6-9800acccc7fd"),
                    BrandName = "Bullpadel"
                },
                  new Brand
                {
                    Id = Guid.Parse("c3ea1eed-d829-4072-b0dd-1eb48694bbee"),
                    BrandName = "Wilson"
                },


           };


        public void Configure(EntityTypeBuilder<Brand> entity)
        {
            entity.HasData(brands);
        }
    }
}
