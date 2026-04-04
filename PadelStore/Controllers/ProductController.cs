using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PadelStore.ViewModels;
using PadelStore.ViewModels.Admin;

using PadelStrore.Services.Core.Contracts;



namespace PadelStore.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;
        private readonly IBrandService brandService;

        public ProductController(IProductService productService, ICategoryService categoryService, IBrandService brandService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
            this.brandService = brandService;   
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index(ProductQueryViewModel model)
        {
            int pageSize = 12;

            if (model.CurrentPage <= 0)
            {
                model.CurrentPage = 1;
            }

            model = await productService.GetFilteredAsync(model, pageSize);

            model.Categories = await categoryService.GetCategoriesAsync();
            model.Brands = await brandService.GetBrandsAsync();

            return View(model);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(Guid id)
        {
            ProductDetailsViewModel? model = await productService.GetDetailsAsync(id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }
    }
}
