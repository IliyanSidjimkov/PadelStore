using Microsoft.AspNetCore.Mvc;
using PadelStore.ViewModels.Admin;
using PadelStrore.Services.Core;
using PadelStrore.Services.Core.Contracts;

namespace PadelStore.Areas.Admin.Controllers
{
    public class AdminProductController : BaseAdminController
    {
        private readonly IProductService productService;

        public AdminProductController(IProductService productService)
        {
            this.productService = productService;
        }


        public async Task<IActionResult> Index()
        {
            IEnumerable<ProductAllViewModel> products = await productService.GetAllAsync();
            return View(products);
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
