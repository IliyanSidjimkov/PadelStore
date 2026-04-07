

using Microsoft.EntityFrameworkCore;
using PadelStore.Data;
using PadelStore.Data.Models;
using PadelStore.ViewModels;
using PadelStrore.Services.Core.Contracts;

namespace PadelStrore.Services.Core
{
    public class ReviewService : IReviewService
    {
        private readonly ShopDbContext context;

        public ReviewService(ShopDbContext context)
        {
            this.context = context;
        }
        public async Task AddAsync(Guid userId, ReviewCreateViewModel model)
        {
            Review review = new Review
            {
                Comment = model.Comment,
                Rating = model.Rating,
                ProductId = model.ProductId,
                UserId = userId
            };

            await context.Reviews.AddAsync(review);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id, Guid userId, bool isAdmin)
        {
            Review? review = await context.Reviews.FindAsync(id);

            if (review == null)
            {
                throw new ArgumentException("Review not found");
            }

            if (isAdmin || review.UserId == userId)
            {
                context.Reviews.Remove(review);
                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ReviewViewModel>> GetAllAsync()
        {
            return await context.Reviews
            .Select(r => new ReviewViewModel
            {
                Id = r.Id,
                Comment = r.Comment,
                Rating = r.Rating,
                UserEmail = r.User.Email!,
                UserId = r.UserId,
                ProductName = r.Product.ProductName,
                ProductId = r.ProductId

            })
            .ToListAsync();
        }

        public async Task<IEnumerable<ReviewViewModel>> GetByProductIdAsync(Guid productId)
        {
            return await context.Reviews
             .Where(r => r.ProductId == productId)
             .Select(r => new ReviewViewModel
             {
                 Id = r.Id,
                 Comment = r.Comment,
                 Rating = r.Rating,
                 UserEmail = r.User.Email!,
                 UserId = r.UserId
             })
             .ToListAsync();
        }
    }
}
