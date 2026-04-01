using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PadelStore.ViewModels.Admin;
using PadelStrore.Services.Core.Contracts;

namespace PadelStore.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            IEnumerable<ProductAllViewModel> products = await productService.GetAllAsync();
            return View(products);
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
