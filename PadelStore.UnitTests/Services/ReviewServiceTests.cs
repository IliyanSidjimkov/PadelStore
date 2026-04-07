
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using PadelStore.Data;
using PadelStore.Data.Models;
using PadelStore.ViewModels;
using PadelStrore.Services.Core;
using Xunit;

namespace PadelStore.UnitTests.Services
{
    public class ReviewServiceTests
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
            ApplicationUser user = new ApplicationUser
            {
                Id = userId,
                FirstName = "First",
                LastName = "Last",
                Email = "test@test.com"
            };

            Product product = new Product
            {
                Id = productId,
                ImageUrl = "img",
                ProductDescription = "Test Description",
                ProductName = "Test Product"
            };

            await context.Users.AddAsync(user);
            await context.Products.AddAsync(product);

            await context.Reviews.AddAsync(new Review
            {
                Id = Guid.NewGuid(),
                Comment = "Nice",
                
                Rating = 5,
                UserId = userId,
                ProductId = productId,
               
                User = user,
                Product = product
            });

            await context.SaveChangesAsync();
        }

        [Fact]
        public async Task AddAsync_ShouldAddReview()
        {
            ShopDbContext context = GetDbContext();
            ReviewService service = new ReviewService(context);

            Guid userId = Guid.NewGuid();
            Guid productId = Guid.NewGuid();

            await context.Products.AddAsync(new Product
            {
                Id = productId,
                ImageUrl = "img",
                ProductDescription = "Test Desc",
                ProductName = "Test"
            });

            await context.SaveChangesAsync();

            ReviewCreateViewModel model = new ReviewCreateViewModel
            {
                Comment = "Great",
                Rating = 5,
                ProductId = productId
            };

            await service.AddAsync(userId, model);

            context.Reviews.Count().Should().Be(1);
        }

        [Fact]
        public async Task DeleteAsync_ShouldDelete_WhenOwner()
        {
            ShopDbContext context = GetDbContext();

            Guid userId = Guid.NewGuid();
            Guid productId = Guid.NewGuid();

            await SeedData(context, userId, productId);

            ReviewService service = new ReviewService(context);

            Review review = context.Reviews.First();

            await service.DeleteAsync(review.Id, userId, false);

            context.Reviews.Count().Should().Be(0);
        }

        [Fact]
        public async Task DeleteAsync_ShouldDelete_WhenAdmin()
        {
            ShopDbContext context = GetDbContext();

            Guid userId = Guid.NewGuid();
            Guid productId = Guid.NewGuid();

            await SeedData(context, userId, productId);

            ReviewService service = new ReviewService(context);

            Review review = context.Reviews.First();

            await service.DeleteAsync(review.Id, Guid.NewGuid(), true);

            context.Reviews.Count().Should().Be(0);
        }

        [Fact]
        public async Task DeleteAsync_ShouldNotDelete_WhenNotOwnerAndNotAdmin()
        {
            ShopDbContext context = GetDbContext();

            Guid userId = Guid.NewGuid();
            Guid productId = Guid.NewGuid();

            await SeedData(context, userId, productId);

            ReviewService service = new ReviewService(context);

            Review review = context.Reviews.First();

            await service.DeleteAsync(review.Id, Guid.NewGuid(), false);

            context.Reviews.Count().Should().Be(1);
        }

        

        [Fact]
        public async Task GetAllAsync_ShouldReturnReviews()
        {
            ShopDbContext context = GetDbContext();

            Guid userId = Guid.NewGuid();
            Guid productId = Guid.NewGuid();

            await SeedData(context, userId, productId);

            ReviewService service = new ReviewService(context);

            IEnumerable<ReviewViewModel> result = await service.GetAllAsync();

            result.Count().Should().Be(1);
            result.First().ProductName.Should().Be("Test Product");
        }

        [Fact]
        public async Task GetByProductIdAsync_ShouldReturnFilteredReviews()
        {
            ShopDbContext context = GetDbContext();

            Guid userId = Guid.NewGuid();
            Guid productId = Guid.NewGuid();

            await SeedData(context, userId, productId);

            ReviewService service = new ReviewService(context);

            IEnumerable<ReviewViewModel> result = await service.GetByProductIdAsync(productId);

            result.Count().Should().Be(1);
        }

        [Fact]
        public async Task GetByProductIdAsync_ShouldReturnEmpty_WhenNoReviews()
        {
            ShopDbContext context = GetDbContext();
            ReviewService service = new ReviewService(context);

            IEnumerable<ReviewViewModel> result = await service.GetByProductIdAsync(Guid.NewGuid());

            result.Should().BeEmpty();
        }
    }
}
