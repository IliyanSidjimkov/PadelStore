

using PadelStore.ViewModels.Admin;

namespace PadelStrore.Services.Core.Contracts
{
    public interface IUserService
    {
        Task<IEnumerable<AdminManageUserViewModel>> GetAllAsync();

        Task AssignRoleAsync(Guid userId, string role, Guid currentAdminId);

        Task RemoveRoleAsync(Guid userId, string role, Guid currentAdminId);

        Task DeleteAsync(Guid userId, Guid currentAdminId);
    }
}
