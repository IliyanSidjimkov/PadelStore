using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PadelStore.Data.Models;
using PadelStore.ViewModels.Admin;
using PadelStrore.Services.Core.Contracts;

namespace PadelStore.Areas.Admin.Controllers
{
    public class AdminUserController : BaseAdminController
    {
        private readonly IUserService userService;
        private readonly UserManager<ApplicationUser> userManager;

        public AdminUserController(IUserService userService, UserManager<ApplicationUser> userManager)
        {
            this.userService = userService;
            this.userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<AdminManageUserViewModel> users = await userService.GetAllAsync();

            return View(users);
        }
        [HttpPost]
        public async Task<IActionResult> AssignRole(Guid userId, string role)
        {
            string? currentUserIdString = userManager.GetUserId(User);

            if (!Guid.TryParse(currentUserIdString, out Guid currentAdminId))
            {
                return Unauthorized();
            }

            await userService.AssignRoleAsync(userId, role, currentAdminId);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveRole(Guid userId, string role)
        {
            string? currentUserIdString = userManager.GetUserId(User);

            if (!Guid.TryParse(currentUserIdString, out Guid currentAdminId))
            {
                return Unauthorized();
            }

            await userService.RemoveRoleAsync(userId, role, currentAdminId);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid userId)
        {
            string? currentUserIdString = userManager.GetUserId(User);

            if (!Guid.TryParse(currentUserIdString, out Guid currentAdminId))
            {
                return Unauthorized();
            }

            await userService.DeleteAsync(userId, currentAdminId);

            return RedirectToAction(nameof(Index));
        }
    }
}
