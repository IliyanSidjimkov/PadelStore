using PadelStore.Data.Models;
using PadelStore.ViewModels.Admin;


namespace PadelStrore.Services.Core.Contracts
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryViewModel>> GetAllAsync();

        Task CreateAsync(CategoryViewModel model);

        Task DeleteAsync(Guid id);
    }
}
