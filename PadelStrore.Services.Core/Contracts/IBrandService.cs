using PadelStore.Data.Models;
using PadelStore.ViewModels.Admin;


namespace PadelStrore.Services.Core.Contracts
{
    public interface IBrandService
    {
        Task<IEnumerable<Brand>> GetAllAsync();

        Task CreateAsync(string name);

        Task DeleteAsync(Guid id);
    }
}
