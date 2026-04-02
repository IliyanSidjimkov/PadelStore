using PadelStore.Data.Models.Enums;
using PadelStore.ViewModels;
using PadelStore.ViewModels.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PadelStrore.Services.Core.Contracts
{
    public interface IOrderService
    {
        Task CreateOrderAsync(Guid userId);
        Task<IEnumerable<OrderViewModel>> GetAllAsync();
        Task ChangeStatusAsync(Guid orderId, OrderStatus status);
        Task<IEnumerable<OrderViewModel>> GetByUserIdAsync(Guid userId);

        Task<OrderDetailsViewModel?> GetDetailsAsync(Guid orderId);
    }
}
