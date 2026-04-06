

using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using PadelStore.Data;
using PadelStore.Data.Models;
using PadelStore.Data.Models.Enums;
using PadelStore.ViewModels;
using PadelStore.ViewModels.Admin;
using PadelStrore.Services.Core;
using Xunit;

namespace PadelStore.UnitTests.Services
{
    public class OrderServiceTests
    {
        private ShopDbContext GetDbContext()
        {
            DbContextOptions<ShopDbContext> options = new DbContextOptionsBuilder<ShopDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new ShopDbContext(options);
        }

        private async Task SeedCart(ShopDbContext context, Guid userId)
        {
            Product product = new Product
            {
                Id = Guid.NewGuid(),
                ProductName = "Test Product",
                ProductDescription = "Description",
                Price = 100,
                ImageUrl = "img"
            };

            await context.Products.AddAsync(product);

            await context.CartItems.AddAsync(new CartItem
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                ProductId = product.Id,
                Quantity = 2,
                Product = product
            });

            await context.SaveChangesAsync();
        }

        [Fact]
        public async Task CreateOrderAsync_ShouldCreateOrder()
        {
            ShopDbContext context = GetDbContext();
            Guid userId = Guid.NewGuid();

            await SeedCart(context, userId);

            OrderService service = new OrderService(context);

            await service.CreateOrderAsync(userId);

            context.Orders.Count().Should().Be(1);
        }

        [Fact]
        public async Task CreateOrderAsync_ShouldClearCart()
        {
            ShopDbContext context = GetDbContext();
            Guid userId = Guid.NewGuid();

            await SeedCart(context, userId);

            OrderService service = new OrderService(context);

            await service.CreateOrderAsync(userId);

            context.CartItems.Count().Should().Be(0);
        }

        [Fact]
        public async Task CreateOrderAsync_ShouldCalculateTotalPriceCorrectly()
        {
            ShopDbContext context = GetDbContext();
            Guid userId = Guid.NewGuid();

            await SeedCart(context, userId);

            OrderService service = new OrderService(context);

            await service.CreateOrderAsync(userId);

            Order order = context.Orders.First();

            order.TotalPrice.Should().Be(200); 
        }

        [Fact]
        public async Task CreateOrderAsync_ShouldDoNothing_WhenCartIsEmpty()
        {
            ShopDbContext context = GetDbContext();
            OrderService service = new OrderService(context);

            await service.CreateOrderAsync(Guid.NewGuid());

            context.Orders.Count().Should().Be(0);
        }

        [Fact]
        public async Task ChangeStatusAsync_ShouldUpdateStatus()
        {
            ShopDbContext context = GetDbContext();

            Order order = new Order
            {
                Id = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                OrderDate = DateTime.UtcNow,
                TotalPrice = 100
            };

            await context.Orders.AddAsync(order);
            await context.SaveChangesAsync();

            OrderService service = new OrderService(context);

            await service.ChangeStatusAsync(order.Id, OrderStatus.Shipped);

            order.Status.Should().Be(OrderStatus.Shipped);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnOrders()
        {
            ShopDbContext context = GetDbContext();

            ApplicationUser user = new ApplicationUser
            {
                Id = Guid.NewGuid(),
                FirstName = "First",
                LastName = "Last",
                Email = "test@test.com"
            };

            Order order = new Order
            {
                Id = Guid.NewGuid(),
                UserId = user.Id,
                User = user,
                OrderDate = DateTime.UtcNow,
                TotalPrice = 50
            };

            await context.Users.AddAsync(user);
            await context.Orders.AddAsync(order);
            await context.SaveChangesAsync();

            OrderService service = new OrderService(context);

            IEnumerable<OrderViewModel> result = await service.GetAllAsync();

            result.Count().Should().Be(1);
        }

        [Fact]
        public async Task GetByUserIdAsync_ShouldReturnOnlyUserOrders()
        {
            ShopDbContext context = GetDbContext();

            Guid userId = Guid.NewGuid();

            await context.Orders.AddAsync(new Order
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                OrderDate = DateTime.UtcNow,
                TotalPrice = 100
            });

            await context.Orders.AddAsync(new Order
            {
                Id = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                OrderDate = DateTime.UtcNow,
                TotalPrice = 200
            });

            await context.SaveChangesAsync();

            OrderService service = new OrderService(context);

            IEnumerable<OrderViewModel> result = await service.GetByUserIdAsync(userId);

            result.Count().Should().Be(1);
        }

        [Fact]
        public async Task GetDetailsAsync_ShouldReturnOrderDetails()
        {
            ShopDbContext context = GetDbContext();

            Product product = new Product
            {
                Id = Guid.NewGuid(),
                ProductName = "Product",
                ProductDescription = "Description",
                Price = 100,
                ImageUrl = "img"
            };

            Order order = new Order
            {
                Id = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                OrderDate = DateTime.UtcNow,
                TotalPrice = 100,
                Items = new List<OrderItem>
                {
                    new OrderItem
                    {
                        Id = Guid.NewGuid(),
                        Product = product,
                        ProductId = product.Id,
                        Quantity = 1,
                        Price = 100
                    }
                }
            };

            await context.Products.AddAsync(product);
            await context.Orders.AddAsync(order);
            await context.SaveChangesAsync();

            OrderService service = new OrderService(context);

            OrderDetailsViewModel? result = await service.GetDetailsAsync(order.Id);

            result.Should().NotBeNull();
            result!.Items.Count().Should().Be(1);
        }

        [Fact]
        public async Task GetDetailsAsync_ShouldReturnNull_WhenNotFound()
        {
            ShopDbContext context = GetDbContext();
            OrderService service = new OrderService(context);

            OrderDetailsViewModel? result = await service.GetDetailsAsync(Guid.NewGuid());

            result.Should().BeNull();
        }
    }
}
