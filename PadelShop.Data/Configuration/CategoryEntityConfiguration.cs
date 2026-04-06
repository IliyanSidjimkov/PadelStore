

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PadelStore.Data.Models;


namespace PadelStore.Data.Configuration
{
    public class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
    {
        private readonly Category[] categories = new Category[]
            {
                new Category
                {
                    Id = Guid.Parse("b6546657-e20f-400c-a541-084f9af110a7"),
                    CategoryName = "Rackets"
                },
                new Category
                {
                    Id = Guid.Parse("ba2f5f1c-a270-43a7-8d32-923a98ab7b3d"),
                    CategoryName = "Balls"
                },
                new Category
                {
                    Id = Guid.Parse("d8d7a869-833a-42dd-8573-8f2ce007de7c"),
                    CategoryName = "Shoes"
                },
                new Category
                {
                    Id = Guid.Parse("c18232f3-981a-4f77-a51e-62d755dcdfb4"),
                    CategoryName = "Accesories"
                }

            };
        public void Configure(EntityTypeBuilder<Category> entity)
        {
            entity.HasData(categories);
        }
    }
}
