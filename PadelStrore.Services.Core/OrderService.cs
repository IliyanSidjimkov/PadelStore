
using Microsoft.EntityFrameworkCore;
using PadelStore.Data;
using PadelStore.Data.Models;
using PadelStore.Data.Models.Enums;
using PadelStore.ViewModels;
using PadelStore.ViewModels.Admin;
using PadelStrore.Services.Core.Contracts;


namespace PadelStrore.Services.Core
{
    public class OrderService : IOrderService
    {
        private readonly ShopDbContext context;

        public OrderService(ShopDbContext context)
        {
            this.context = context;
        }

        public async Task ChangeStatusAsync(Guid orderId, OrderStatus status)
        {
            Order? order = await context.Orders.FindAsync(orderId);

            if (order != null)
            {
                order.Status = status;
                await context.SaveChangesAsync();
            }
        }

        public async Task CreateOrderAsync(Guid userId)
        {
            List<CartItem> cartItems = await context.CartItems
            .Where(c => c.UserId == userId)
            .Include(c => c.Product)
            .ToListAsync();

            if (!cartItems.Any())
            {
                return;
            }

            Order order = new Order
            {
                UserId = userId,
                OrderDate = DateTime.UtcNow,
                TotalPrice = cartItems.Sum(c => c.Product.Price * c.Quantity)
            };

            foreach (CartItem item in cartItems)
            {
                order.Items.Add(new OrderItem
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    Price = item.Product.Price
                });
            }

            await context.Orders.AddAsync(order);

            
            context.CartItems.RemoveRange(cartItems);

            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<OrderViewModel>> GetAllAsync()
        {

            return await context.Orders
      .Include(o => o.User)
      .Select(o => new OrderViewModel
      {
          Id = o.Id,
          UserEmail = o.User.Email!,
          TotalPrice = o.TotalPrice,
          CreatedOn = o.OrderDate,
          Status = o.Status.ToString()
      })
      .ToListAsync();
        }

        public async Task<IEnumerable<OrderViewModel>> GetByUserIdAsync(Guid userId)
        {
            return await context.Orders
       .Where(o => o.UserId == userId)
       .Select(o => new OrderViewModel
       {
           Id = o.Id,
           TotalPrice = o.TotalPrice,
           CreatedOn = o.OrderDate,
           Status = o.Status.ToString()
       })
       .ToListAsync();
        }

        public async Task<OrderDetailsViewModel?> GetDetailsAsync(Guid orderId)
        {
            OrderDetailsViewModel? order = await context.Orders
        .Where(o => o.Id == orderId)
        .Select(o => new OrderDetailsViewModel
        {
            Id = o.Id,
            CreatedOn = o.OrderDate,
            TotalPrice = o.TotalPrice,
            Status = o.Status.ToString(),

            Items = o.Items.Select(i => new OrderItemViewModel
            {
                ProductName = i.Product.ProductName,
                ImageUrl = i.Product.ImageUrl,
                Quantity = i.Quantity,
                Price = i.Price
            })
        })
        .FirstOrDefaultAsync();

            return order;
        }
    }


}

