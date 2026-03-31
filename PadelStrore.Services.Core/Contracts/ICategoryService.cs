using PadelStore.Data.Models;
using PadelStore.ViewModels.Admin;


namespace PadelStrore.Services.Core.Contracts
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllAsync();

        Task CreateAsync(string name);

        Task DeleteAsync(Guid id);
    }
}
