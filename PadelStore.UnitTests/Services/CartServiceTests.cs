

using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using PadelStore.Data;
using PadelStore.Data.Models;
using PadelStore.ViewModels;
using PadelStrore.Services.Core;
using Xunit;

namespace PadelStore.UnitTests.Services
{
    public class CartServiceTests
    {
        private ShopDbContext GetDbContext()
        {
            DbContextOptions<ShopDbContext> options = new DbContextOptionsBuilder<ShopDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new ShopDbContext(options);
        }

        private async Task SeedData(ShopDbContext context, Guid userId, Guid productId)
        {
            Product product = new Product
            {
                Id = productId,
                ProductName = "Test Product",
                ProductDescription = "Description",
                ImageUrl = "img",
                Price = 100
                
            };

            await context.Products.AddAsync(product);

            await context.CartItems.AddAsync(new CartItem
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                ProductId = productId,
                Quantity = 1,
                Product = product
            });

            await context.SaveChangesAsync();
        }

        [Fact]
        public async Task AddToCartAsync_ShouldAddNewItem_WhenNotExists()
        {
            ShopDbContext context = GetDbContext();
            CartService service = new CartService(context);

            Guid userId = Guid.NewGuid();
            Guid productId = Guid.NewGuid();

            await context.Products.AddAsync(new Product
            {
                Id = productId,
                ProductName = "Test",
                ImageUrl = "img",
                ProductDescription= "Description",
                Price = 10
            });

            await context.SaveChangesAsync();

            await service.AddToCartAsync(userId, productId);

            context.CartItems.Count().Should().Be(1);
        }

        [Fact]
        public async Task AddToCartAsync_ShouldIncreaseQuantity_WhenExists()
        {
            ShopDbContext context = GetDbContext();

            Guid userId = Guid.NewGuid();
            Guid productId = Guid.NewGuid();

            await SeedData(context, userId, productId);

            CartService service = new CartService(context);

            await service.AddToCartAsync(userId, productId);

            CartItem item = context.CartItems.First();
            item.Quantity.Should().Be(2);
        }

        [Fact]
        public async Task IncreaseQuantityAsync_ShouldIncrease()
        {
            ShopDbContext context = GetDbContext();

            Guid userId = Guid.NewGuid();
            Guid productId = Guid.NewGuid();

            await SeedData(context, userId, productId);

            CartService service = new CartService(context);

            CartItem item = context.CartItems.First();

            await service.IncreaseQuantityAsync(item.Id);

            item.Quantity.Should().Be(2);
        }

        [Fact]
        public async Task DecreaseQuantityAsync_ShouldDecrease_WhenMoreThanOne()
        {
            ShopDbContext context = GetDbContext();

            Guid userId = Guid.NewGuid();
            Guid productId = Guid.NewGuid();

            await SeedData(context, userId, productId);

            CartItem item = context.CartItems.First();
            item.Quantity = 2;
            await context.SaveChangesAsync();

            CartService service = new CartService(context);

            await service.DecreaseQuantityAsync(item.Id);

            item.Quantity.Should().Be(1);
        }

        [Fact]
        public async Task DecreaseQuantityAsync_ShouldRemove_WhenQuantityIsOne()
        {
            ShopDbContext context = GetDbContext();

            Guid userId = Guid.NewGuid();
            Guid productId = Guid.NewGuid();

            await SeedData(context, userId, productId);

            CartService service = new CartService(context);

            CartItem item = context.CartItems.First();

            await service.DecreaseQuantityAsync(item.Id);

            context.CartItems.Count().Should().Be(0);
        }

        [Fact]
        public async Task RemoveAsync_ShouldRemoveItem()
        {
            ShopDbContext context = GetDbContext();

            Guid userId = Guid.NewGuid();
            Guid productId = Guid.NewGuid();

            await SeedData(context, userId, productId);

            CartService service = new CartService(context);

            CartItem item = context.CartItems.First();

            await service.RemoveAsync(item.Id);

            context.CartItems.Count().Should().Be(0);
        }

        [Fact]
        public async Task GetCartAsync_ShouldReturnUserItems()
        {
            ShopDbContext context = GetDbContext();

            Guid userId = Guid.NewGuid();
            Guid productId = Guid.NewGuid();

            await SeedData(context, userId, productId);

            CartService service = new CartService(context);

            IEnumerable<CartItemViewModel> result = await service.GetCartAsync(userId);

            result.Count().Should().Be(1);
            result.First().ProductName.Should().Be("Test Product");
        }

        [Fact]
        public async Task GetCartAsync_ShouldReturnEmpty_WhenNoItems()
        {
            ShopDbContext context = GetDbContext();
            CartService service = new CartService(context);

            IEnumerable<CartItemViewModel> result = await service.GetCartAsync(Guid.NewGuid());

            result.Should().BeEmpty();
        }
    }
}
