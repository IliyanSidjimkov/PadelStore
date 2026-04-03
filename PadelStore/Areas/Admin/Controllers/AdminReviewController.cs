using Microsoft.AspNetCore.Mvc;
using PadelStore.ViewModels;
using PadelStrore.Services.Core.Contracts;

namespace PadelStore.Areas.Admin.Controllers
{
    public class AdminReviewController : BaseAdminController
    {
        private readonly IReviewService reviewService;

        public AdminReviewController(IReviewService reviewService)
        {
            this.reviewService = reviewService;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<ReviewViewModel> reviews = await reviewService.GetAllAsync();
            return View(reviews);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            await reviewService.DeleteAsync(id, Guid.Empty, true);
            return RedirectToAction(nameof(Index));
        }
    }
}
