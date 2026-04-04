using Microsoft.AspNetCore.Mvc;
using PadelStore.ViewModels;
using PadelStore.ViewModels.Admin;
using PadelStrore.Services.Core;
using PadelStrore.Services.Core.Contracts;

namespace PadelStore.Areas.Admin.Controllers
{
    public class AdminProductController : BaseAdminController
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;
        private readonly IBrandService brandService;

        public AdminProductController(IProductService productService, ICategoryService categoryService, IBrandService brandService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
            this.brandService = brandService;
        }


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
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ProductCreateViewModel model = new ProductCreateViewModel
            {
                Categories = await productService.GetCategoriesAsync(),
                Brands = await productService.GetBrandsAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = await productService.GetCategoriesAsync();
                model.Brands = await productService.GetBrandsAsync();
                return View(model);
            }

            try
            {
                await productService.CreateAsync(model);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                ModelState.AddModelError(string.Empty, "An error occurred while adding product. Please try again.");
                return View(model);
            }

           
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            ProductEditViewModel? model = await productService.GetByIdAsync(id);

            if (model == null)
            {
                return NotFound();
            }

            model.Categories = await productService.GetCategoriesAsync();
            model.Brands = await productService.GetBrandsAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = await productService.GetCategoriesAsync();
                model.Brands = await productService.GetBrandsAsync();
                return View(model);
            }

            try
            {
                await productService.UpdateAsync(model);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                ModelState.AddModelError(string.Empty, "An error occurred while editing the product. Please try again.");
                return View(model);

            }
            
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            await productService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

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
