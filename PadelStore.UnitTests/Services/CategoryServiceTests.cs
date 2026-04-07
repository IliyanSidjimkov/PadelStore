

using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PadelStore.Data;
using PadelStore.Data.Models;
using PadelStore.ViewModels.Admin;
using PadelStrore.Services.Core;
using Xunit;

namespace PadelStore.UnitTests.Services
{
    public class CategoryServiceTests
    {
        private ShopDbContext GetDbContext()
        {
            DbContextOptions<ShopDbContext> options = new DbContextOptionsBuilder<ShopDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new ShopDbContext(options);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnAllCategories()
        {
            
            ShopDbContext context = GetDbContext();

            context.Categories.AddRange(
                new Category { Id = Guid.NewGuid(), CategoryName = "Shoes" },
                new Category { Id = Guid.NewGuid(), CategoryName = "Rackets" }
            );

            await context.SaveChangesAsync();

            CategoryService service = new CategoryService(context);

            
            IEnumerable<CategoryViewModel> result = await service.GetAllAsync();

            
            result.Count().Should().Be(2);
            result.Should().Contain(c => c.CategoryName == "Shoes");
            result.Should().Contain(c => c.CategoryName == "Rackets");
        }

        [Fact]
        public async Task CreateAsync_ShouldAddCategory()
        {
            
            ShopDbContext context = GetDbContext();
            CategoryService service = new CategoryService(context);

            CategoryViewModel model = new CategoryViewModel
            {
                CategoryName = "Balls"
            };

            
            await service.CreateAsync(model);

           
            context.Categories.Count().Should().Be(1);
            context.Categories.First().CategoryName.Should().Be("Balls");
        }

        [Fact]
        public async Task DeleteAsync_ShouldRemoveCategory_WhenExists()
        {
            
            ShopDbContext context = GetDbContext();

            Category category = new Category
            {
                Id = Guid.NewGuid(),
                CategoryName = "Clothes"
            };

            context.Categories.Add(category);
            await context.SaveChangesAsync();

            CategoryService service = new CategoryService(context);
 
            await service.DeleteAsync(category.Id);

            
            context.Categories.Count().Should().Be(0);
        }

        

        [Fact]
        public async Task GetCategoriesAsync_ShouldReturnSelectListItems()
        {
           
            ShopDbContext context = GetDbContext();

            Category category = new Category
            {
                Id = Guid.NewGuid(),
                CategoryName = "Accessories"
            };

            context.Categories.Add(category);
            await context.SaveChangesAsync();

            CategoryService service = new CategoryService(context);

          
            IEnumerable<SelectListItem> result = await service.GetCategoriesAsync();

          
            result.Count().Should().Be(1);
            result.First().Text.Should().Be("Accessories");
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnEmpty_WhenNoCategories()
        {
          
            ShopDbContext context = GetDbContext();
            CategoryService service = new CategoryService(context);

            
            IEnumerable<CategoryViewModel> result = await service.GetAllAsync();

            
            result.Should().BeEmpty();
        }
    }
}
