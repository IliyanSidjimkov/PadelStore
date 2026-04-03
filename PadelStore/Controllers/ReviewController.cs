using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PadelStore.Data.Models;
using PadelStore.ViewModels;
using PadelStrore.Services.Core.Contracts;

namespace PadelStore.Controllers
{
    public class ReviewController : BaseController
    {
        private readonly IReviewService reviewService;
        private readonly UserManager<ApplicationUser> userManager;

        public ReviewController(IReviewService reviewService, UserManager<ApplicationUser> userManager)
        {
            this.reviewService = reviewService;
            this.userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Add(ReviewCreateViewModel model)
        {
            string? userIdString = userManager.GetUserId(User);

            if (!Guid.TryParse(userIdString, out Guid userId))
            {
                return Unauthorized();
            }

            await reviewService.AddAsync(userId, model);

            return RedirectToAction("Details", "Product", new { id = model.ProductId });
        }

        public async Task<IActionResult> Delete(Guid id, Guid productId)
        {
            string? userIdString = userManager.GetUserId(User);

            if (!Guid.TryParse(userIdString, out Guid userId))
            {
                return Unauthorized();
            }

            bool isAdmin = User.IsInRole("Admin");

            await reviewService.DeleteAsync(id, userId, isAdmin);

            return RedirectToAction("Details", "Product", new { id = productId });
        }
    }
}
