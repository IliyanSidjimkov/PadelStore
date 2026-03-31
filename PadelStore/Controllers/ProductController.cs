using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
            var products = await productService.GetAllAsync();
            return View(products);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(Guid id)
        {
            var model = await productService.GetDetailsAsync(id);

            if (model == null) return NotFound();

            return View(model);
        }
    }
}
