using Microsoft.AspNetCore.Mvc;
using PadelStore.ViewModels.Admin;
using PadelStrore.Services.Core;
using PadelStrore.Services.Core.Contracts;

namespace PadelStore.Areas.Admin.Controllers
{
    public class AdminCategoryController : BaseAdminController
    {
        private readonly ICategoryService categoryService;

        public AdminCategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        public async Task<IActionResult> Index()
        {
            var categories = await categoryService.GetAllAsync();
            return View(categories);
        }

        [HttpPost]
        public async Task<IActionResult> Create(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                await categoryService.CreateAsync(name);
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            await categoryService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
