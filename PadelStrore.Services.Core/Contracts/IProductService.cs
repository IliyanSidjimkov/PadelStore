using Microsoft.AspNetCore.Mvc.Rendering;
using PadelStore.ViewModels;
using PadelStore.ViewModels.Admin;


namespace PadelStrore.Services.Core.Contracts
{
    public interface IProductService
    {
        Task CreateAsync(ProductCreateViewModel model);

        Task<IEnumerable<SelectListItem>> GetCategoriesAsync();

        Task<IEnumerable<SelectListItem>> GetBrandsAsync();

        Task<IEnumerable<ProductAllViewModel>> GetAllAsync();

        Task<ProductEditViewModel?> GetByIdAsync(Guid id);

        Task<ProductDetailsViewModel?> GetDetailsAsync(Guid id);

        Task UpdateAsync(ProductEditViewModel model);

        Task DeleteAsync(Guid id);

        Task<PageViewModel> GetPagedAsync(int page, int pageSize);
    }
}
