using Microsoft.AspNetCore.Mvc;
using PadelStore.Data.Models;
using PadelStore.ViewModels.Admin;
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
            IEnumerable<BrandViewModel> brands = await brandService.GetAllAsync();
            return View(brands);
        }

        [HttpPost]
        public async Task<IActionResult> Create(BrandViewModel model)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<BrandViewModel> brands = await brandService.GetAllAsync();
                return View("Index", brands);
            }

            try
            {
                await brandService.CreateAsync(model);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
                ModelState.AddModelError(string.Empty, "An error occurred while adding a brand. Please try again.");
                return View(model);
            }
        }

            

        public async Task<IActionResult> Delete(Guid id)
        {

            
            try
            {
                await brandService.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
        }
    }
 }
