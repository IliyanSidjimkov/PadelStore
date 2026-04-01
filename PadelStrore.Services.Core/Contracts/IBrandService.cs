using PadelStore.Data.Models;
using PadelStore.ViewModels.Admin;


namespace PadelStrore.Services.Core.Contracts
{
    public interface IBrandService
    {
        Task<IEnumerable<BrandViewModel>> GetAllAsync();

        Task CreateAsync(BrandViewModel model);

        Task DeleteAsync(Guid id);
    }
}
