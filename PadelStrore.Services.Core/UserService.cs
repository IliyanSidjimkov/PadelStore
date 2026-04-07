

using Microsoft.AspNetCore.Identity;
using PadelStore.Data.Models;
using PadelStore.ViewModels.Admin;
using PadelStrore.Services.Core.Contracts;

namespace PadelStrore.Services.Core
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole<Guid>> roleManager;

        public UserService(UserManager<ApplicationUser> userManager,
                           RoleManager<IdentityRole<Guid>> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        public async Task AssignRoleAsync(Guid userId, string role, Guid currentAdminId)
        {
            ApplicationUser? user = await userManager.FindByIdAsync(userId.ToString());

            if (user == null || !await roleManager.RoleExistsAsync(role))
            {
                return;
            }

            
            if (userId == currentAdminId)
            {
                return;
            }

            await userManager.AddToRoleAsync(user, role);
        }

        public async Task DeleteAsync(Guid userId, Guid currentAdminId)
        {
            
            if (userId == currentAdminId)
            {
                throw new InvalidOperationException("Admin cannot delete himself");
            }

            ApplicationUser? user = await userManager.FindByIdAsync(userId.ToString());

            if (user != null)
            {
                await userManager.DeleteAsync(user);
            }
        }

        public async Task<IEnumerable<AdminManageUserViewModel>> GetAllAsync()
        {
            List<ApplicationUser> users = userManager.Users.ToList();

            List<AdminManageUserViewModel> result = new();

            foreach (ApplicationUser user in users)
            {
                IList<string> roles = await userManager.GetRolesAsync(user);

                result.Add(new AdminManageUserViewModel
                {
                    Id = user.Id,
                    Email = user.Email!,
                    Roles = roles
                });
            }

            return result;
        }

        public async Task RemoveRoleAsync(Guid userId, string role, Guid currentAdminId)
        {
            ApplicationUser? user = await userManager.FindByIdAsync(userId.ToString());

            if (user == null)
            {
                return;
            }

           
            if (userId == currentAdminId && role == "Admin")
            {
                return;
            }

            await userManager.RemoveFromRoleAsync(user, role);
        }
    }
}
