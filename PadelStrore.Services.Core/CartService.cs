using Microsoft.EntityFrameworkCore;
using PadelStore.Data;
using PadelStore.Data.Models;
using PadelStore.ViewModels;
using PadelStrore.Services.Core.Contracts;

namespace PadelStrore.Services.Core
{
    public class CartService : ICartService
    {
        private readonly ShopDbContext context;

        public CartService(ShopDbContext context)
        {
            this.context = context;
        }
        public async Task AddToCartAsync(Guid userId, Guid productId)
        {
            CartItem? existing = await context.CartItems
             .FirstOrDefaultAsync(c => c.UserId == userId && c.ProductId == productId);

            if (existing != null)
            {
                existing.Quantity++;
            }
            else
            {
                CartItem item = new CartItem
                {
                    UserId = userId,
                    ProductId = productId,
                    Quantity = 1
                };

                await context.CartItems.AddAsync(item);
            }

            await context.SaveChangesAsync();
        }

        public async Task DecreaseQuantityAsync(Guid id)
        {
            CartItem? item = await context.CartItems.FindAsync(id);

            if (item != null)
            {
                if (item.Quantity > 1)
                {
                    item.Quantity--;
                }
                else
                {
                    context.CartItems.Remove(item);
                }

                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<CartItemViewModel>> GetCartAsync(Guid userId)
        {
            return await context.CartItems
           .Where(c => c.UserId == userId)
           .Select(c => new CartItemViewModel
           {
               Id = c.Id,
               ProductId= c.ProductId,
               ProductName = c.Product.ProductName,
               Price = c.Product.Price,
               Quantity = c.Quantity,
               ImageUrl = c.Product.ImageUrl
           })
           .ToListAsync();
        }

        public async Task IncreaseQuantityAsync(Guid id)
        {
            CartItem? item = await context.CartItems.FindAsync(id);

            if (item != null)
            {
                item.Quantity++;
                await context.SaveChangesAsync();
            }
        }

        public async Task RemoveAsync(Guid cartItemId)
        {
            CartItem? item = await context.CartItems.FindAsync(cartItemId);

            if (item != null)
            {
                context.CartItems.Remove(item);
                await context.SaveChangesAsync();
            }

        }
    }
}
