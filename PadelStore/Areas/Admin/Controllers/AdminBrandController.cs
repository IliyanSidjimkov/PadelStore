using Microsoft.AspNetCore.Mvc;
using PadelStore.ViewModels.Admin;
using PadelStrore.Services.Core;
using PadelStrore.Services.Core.Contracts;

namespace PadelStore.Areas.Admin.Controllers
{
    public class AdminBrandController : BaseAdminController
    {
        private readonly IBrandService brandService;

        public AdminBrandController(IBrandService brandService)
        {
            this.brandService = brandService;
        }

        public async Task<IActionResult> Index()
        {
            var brands = await brandService.GetAllAsync();
            return View(brands);
        }

        [HttpPost]
        public async Task<IActionResult> Create(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                await brandService.CreateAsync(name);
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            await brandService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
 }
