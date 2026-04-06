

using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using PadelStore.Data;
using PadelStore.Data.Models;
using PadelStore.ViewModels;
using PadelStore.ViewModels.Admin;
using PadelStrore.Services.Core;
using Xunit;

namespace PadelStore.UnitTests.Services
{
    public class ProductServiceTests
    {
        private ShopDbContext GetDbContext()
        {
            DbContextOptions<ShopDbContext> options = new DbContextOptionsBuilder<ShopDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new ShopDbContext(options);
        }

        private async Task SeedData(ShopDbContext context)
        {
            Category category = new Category
            {
                Id = Guid.NewGuid(),
                CategoryName = "Shoes"
            };

            Brand brand = new Brand
            {
                Id = Guid.NewGuid(),
                BrandName = "Nike"
            };

            await context.Categories.AddAsync(category);
            await context.Brands.AddAsync(brand);

            await context.Products.AddAsync(new Product
            {
                Id = Guid.NewGuid(),
                ProductName = "Test Product",
                Price = 100,
                ProductDescription = "Test Description",
                ImageUrl = "img",
                CategoryId = category.Id,
                BrandId = brand.Id,
                Category = category,
                Brand = brand
            });

            await context.SaveChangesAsync();
        }

        [Fact]
        public async Task CreateAsync_ShouldAddProduct()
        {
            ShopDbContext context = GetDbContext();
            await SeedData(context);

            ProductService service = new ProductService(context);

            Category category = context.Categories.First();
            Brand brand = context.Brands.First();

            ProductCreateViewModel model = new ProductCreateViewModel
            {
                ProductName = "New Product",
                ProductDescription = "Description of the product",
                Price = 50,
                ImageUrl = "img",
                CategoryId = category.Id,
                BrandId = brand.Id
            };

            await service.CreateAsync(model);

            context.Products.Count().Should().Be(2);
        }

        [Fact]
        public async Task DeleteAsync_ShouldSoftDeleteProduct()
        {
            ShopDbContext context = GetDbContext();
            await SeedData(context);

            ProductService service = new ProductService(context);

            Product product = context.Products.First();

            await service.DeleteAsync(product.Id);

            product.IsDeleted.Should().BeTrue();
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnProducts()
        {
            ShopDbContext context = GetDbContext();
            await SeedData(context);

            ProductService service = new ProductService(context);

            IEnumerable<ProductAllViewModel> result = await service.GetAllAsync();

            result.Count().Should().Be(1);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnProduct()
        {
            ShopDbContext context = GetDbContext();
            await SeedData(context);

            ProductService service = new ProductService(context);

            Product product = context.Products.First();

            ProductEditViewModel? result = await service.GetByIdAsync(product.Id);

            result.Should().NotBeNull();
            result!.ProductName.Should().Be(product.ProductName);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnNull_WhenNotFound()
        {
            ShopDbContext context = GetDbContext();

            ProductService service = new ProductService(context);

            ProductEditViewModel? result = await service.GetByIdAsync(Guid.NewGuid());

            result.Should().BeNull();
        }

        [Fact]
        public async Task UpdateAsync_ShouldUpdateProduct()
        {
            ShopDbContext context = GetDbContext();
            await SeedData(context);

            ProductService service = new ProductService(context);

            Product product = context.Products.First();

            ProductEditViewModel model = new ProductEditViewModel
            {
                Id = product.Id,
                ProductName = "Updated",
                ProductDescription = "Updated Desc",
                Price = 200,
                ImageUrl = "newimg",
                CategoryId = product.CategoryId,
                BrandId = product.BrandId
            };

            await service.UpdateAsync(model);

            product.ProductName.Should().Be("Updated");
        }

        [Fact]
        public async Task GetDetailsAsync_ShouldReturnOnlyNotDeleted()
        {
            ShopDbContext context = GetDbContext();
            await SeedData(context);

            Product product = context.Products.First();
            product.IsDeleted = true;
            await context.SaveChangesAsync();

            ProductService service = new ProductService(context);

            ProductDetailsViewModel? result = await service.GetDetailsAsync(product.Id);

            result.Should().BeNull();
        }

        [Fact]
        public async Task GetFilteredAsync_ShouldFilterBySearchTerm()
        {
            ShopDbContext context = GetDbContext();
            await SeedData(context);

            ProductService service = new ProductService(context);

            ProductQueryViewModel model = new ProductQueryViewModel
            {
                SearchTerm = "Test",
                CurrentPage = 1
            };

            ProductQueryViewModel result = await service.GetFilteredAsync(model, 10);

            result.Products.Count().Should().Be(1);
        }

        [Fact]
        public async Task GetFilteredAsync_ShouldPaginateCorrectly()
        {
            ShopDbContext context = GetDbContext();

            Category category = new Category { Id = Guid.NewGuid(), CategoryName = "C" };
            Brand brand = new Brand { Id = Guid.NewGuid(), BrandName = "B" };

            await context.Categories.AddAsync(category);
            await context.Brands.AddAsync(brand);

            for (int i = 0; i < 5; i++)
            {
                await context.Products.AddAsync(new Product
                {
                    Id = Guid.NewGuid(),
                    ProductName = "P" + i,
                    Price = 10,
                    ProductDescription = "D",
                    ImageUrl ="img",
                    CategoryId = category.Id,
                    BrandId = brand.Id
                });
            }

            await context.SaveChangesAsync();

            ProductService service = new ProductService(context);

            ProductQueryViewModel model = new ProductQueryViewModel
            {
                CurrentPage = 2
            };

            ProductQueryViewModel result = await service.GetFilteredAsync(model, 2);

            result.Products.Count().Should().Be(2);
            result.TotalPages.Should().Be(3);
        }

        [Fact]
        public async Task GetPagedAsync_ShouldReturnCorrectPage()
        {
            ShopDbContext context = GetDbContext();
            await SeedData(context);

            ProductService service = new ProductService(context);

            PageViewModel result = await service.GetPagedAsync(1, 10);

            result.Products.Count().Should().Be(1);
            result.CurrentPage.Should().Be(1);
        }
    }
}
