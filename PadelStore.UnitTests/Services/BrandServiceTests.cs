

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
    public class BrandServiceTests
    {
        private ShopDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<ShopDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new ShopDbContext(options);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnAllBrands()
        {
            
            var context = GetDbContext();

            context.Brands.AddRange(
                new Brand { Id = Guid.NewGuid(), BrandName = "Nike" },
                new Brand { Id = Guid.NewGuid(), BrandName = "Adidas" }
            );

            await context.SaveChangesAsync();

            BrandService service = new BrandService(context);


            IEnumerable<BrandViewModel> result = await service.GetAllAsync();

            
            result.Should().HaveCount(2);
            result.Should().Contain(b => b.Brand == "Nike");
            result.Should().Contain(b => b.Brand == "Adidas");
        }

        [Fact]
        public async Task CreateAsync_ShouldAddBrand()
        {
            
            ShopDbContext context = GetDbContext();
            BrandService service = new BrandService(context);

            BrandViewModel model = new BrandViewModel
            {
                Brand = "Wilson"
            };

            
            await service.CreateAsync(model);

            
            context.Brands.Count().Should().Be(1);
            context.Brands.First().BrandName.Should().Be("Wilson");
        }

        [Fact]
        public async Task DeleteAsync_ShouldRemoveBrand_WhenExists()
        {
            
            ShopDbContext context = GetDbContext();

            Brand brand = new Brand
            {
                Id = Guid.NewGuid(),
                BrandName = "Babolat"
            };

            context.Brands.Add(brand);
            await context.SaveChangesAsync();

            BrandService service = new BrandService(context);

            
            await service.DeleteAsync(brand.Id);

            
            context.Brands.Count().Should().Be(0);
        }

        

        [Fact]
        public async Task GetBrandsAsync_ShouldReturnSelectListItems()
        {
           
            ShopDbContext context = GetDbContext();

            context.Brands.Add(new Brand
            {
                Id = Guid.NewGuid(),
                BrandName = "Head"
            });

            await context.SaveChangesAsync();

            BrandService service = new BrandService(context);


            IEnumerable<SelectListItem> result = await service.GetBrandsAsync();

            result.Should().HaveCount(1);
            result.First().Text.Should().Be("Head");
        }
        [Fact]
        public async Task GetAllAsync_ShouldReturnEmpty_WhenNoBrands()
        {
            ShopDbContext context = GetDbContext();
            BrandService service = new BrandService(context);

            IEnumerable<BrandViewModel> result = await service.GetAllAsync();

            result.Should().BeEmpty();
        }
    }
}

