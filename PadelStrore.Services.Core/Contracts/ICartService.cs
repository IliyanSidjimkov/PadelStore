using PadelStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PadelStrore.Services.Core.Contracts
{
    public interface ICartService
    {
        Task AddToCartAsync(Guid userId, Guid productId);

        Task<IEnumerable<CartItemViewModel>> GetCartAsync(Guid userId);

        Task RemoveAsync(Guid cartItemId);

        Task IncreaseQuantityAsync(Guid id);

        Task DecreaseQuantityAsync(Guid id);

        Task<bool> IsOwnerAsync(Guid cartItemId, Guid userId);
    }
}
