

using PadelStore.ViewModels;

namespace PadelStrore.Services.Core.Contracts
{
    public interface IReviewService
    {
        Task AddAsync(Guid userId, ReviewCreateViewModel model);

        Task<IEnumerable<ReviewViewModel>> GetByProductIdAsync(Guid productId);

        Task DeleteAsync(Guid id, Guid userId, bool isAdmin);

        Task<IEnumerable<ReviewViewModel>> GetAllAsync();
    }
}
