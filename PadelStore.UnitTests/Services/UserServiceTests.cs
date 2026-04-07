

using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using Moq;
using PadelStore.Data.Models;
using PadelStore.ViewModels.Admin;
using PadelStrore.Services.Core;
using Xunit;

namespace PadelStore.UnitTests.Services
{
    public class UserServiceTests
    {
        private Mock<UserManager<ApplicationUser>> GetUserManagerMock()
        {
            Mock<IUserStore<ApplicationUser>> store = new Mock<IUserStore<ApplicationUser>>();

            Mock<UserManager<ApplicationUser>> userManagerMock =
                new Mock<UserManager<ApplicationUser>>(
                    store.Object, null!, null!, null!, null!, null!, null!, null!, null!);

            return userManagerMock;
        }

        private Mock<RoleManager<IdentityRole<Guid>>> GetRoleManagerMock()
        {
            Mock<IRoleStore<IdentityRole<Guid>>> roleStore = new Mock<IRoleStore<IdentityRole<Guid>>>();

            Mock<RoleManager<IdentityRole<Guid>>> roleManagerMock =
                new Mock<RoleManager<IdentityRole<Guid>>>(roleStore.Object, null!, null!, null!, null!);

            return roleManagerMock;
        }

        [Fact]
        public async Task AssignRoleAsync_ShouldAddRole()
        {
            Mock<UserManager<ApplicationUser>> userManagerMock = GetUserManagerMock();
            Mock<RoleManager<IdentityRole<Guid>>> roleManagerMock = GetRoleManagerMock();

            ApplicationUser user = new ApplicationUser
            {
                Id = Guid.NewGuid()
            };

            roleManagerMock.Setup(r => r.RoleExistsAsync("Admin")).ReturnsAsync(true);
            userManagerMock.Setup(u => u.FindByIdAsync(user.Id.ToString())).ReturnsAsync(user);

            UserService service = new UserService(userManagerMock.Object, roleManagerMock.Object);

            await service.AssignRoleAsync(user.Id, "Admin", Guid.NewGuid());

            userManagerMock.Verify(u => u.AddToRoleAsync(user, "Admin"), Times.Once);
        }

        [Fact]
        public async Task AssignRoleAsync_ShouldNotAssign_WhenSameAdmin()
        {
            Mock<UserManager<ApplicationUser>> userManagerMock = GetUserManagerMock();
            Mock<RoleManager<IdentityRole<Guid>>> roleManagerMock = GetRoleManagerMock();

            Guid id = Guid.NewGuid();

            ApplicationUser user = new ApplicationUser
            {
                Id = id
            };

            roleManagerMock.Setup(r => r.RoleExistsAsync("Admin")).ReturnsAsync(true);
            userManagerMock.Setup(u => u.FindByIdAsync(id.ToString())).ReturnsAsync(user);

            UserService service = new UserService(userManagerMock.Object, roleManagerMock.Object);

            await service.AssignRoleAsync(id, "Admin", id);

            userManagerMock.Verify(u => u.AddToRoleAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public async Task DeleteAsync_ShouldDeleteUser()
        {
            Mock<UserManager<ApplicationUser>> userManagerMock = GetUserManagerMock();
            Mock<RoleManager<IdentityRole<Guid>>> roleManagerMock = GetRoleManagerMock();

            ApplicationUser user = new ApplicationUser
            {
                Id = Guid.NewGuid()
            };

            userManagerMock.Setup(u => u.FindByIdAsync(user.Id.ToString())).ReturnsAsync(user);

            UserService service = new UserService(userManagerMock.Object, roleManagerMock.Object);

            await service.DeleteAsync(user.Id, Guid.NewGuid());

            userManagerMock.Verify(u => u.DeleteAsync(user), Times.Once);
        }

       

        [Fact]
        public async Task RemoveRoleAsync_ShouldRemoveRole()
        {
            Mock<UserManager<ApplicationUser>> userManagerMock = GetUserManagerMock();
            Mock<RoleManager<IdentityRole<Guid>>> roleManagerMock = GetRoleManagerMock();

            ApplicationUser user = new ApplicationUser
            {
                Id = Guid.NewGuid()
            };

            userManagerMock.Setup(u => u.FindByIdAsync(user.Id.ToString())).ReturnsAsync(user);

            UserService service = new UserService(userManagerMock.Object, roleManagerMock.Object);

            await service.RemoveRoleAsync(user.Id, "User", Guid.NewGuid());

            userManagerMock.Verify(u => u.RemoveFromRoleAsync(user, "User"), Times.Once);
        }

        [Fact]
        public async Task RemoveRoleAsync_ShouldNotRemoveAdminRoleFromSelf()
        {
            Mock<UserManager<ApplicationUser>> userManagerMock = GetUserManagerMock();
            Mock<RoleManager<IdentityRole<Guid>>> roleManagerMock = GetRoleManagerMock();

            Guid id = Guid.NewGuid();

            ApplicationUser user = new ApplicationUser
            {
                Id = id
            };

            userManagerMock.Setup(u => u.FindByIdAsync(id.ToString())).ReturnsAsync(user);

            UserService service = new UserService(userManagerMock.Object, roleManagerMock.Object);

            await service.RemoveRoleAsync(id, "Admin", id);

            userManagerMock.Verify(u => u.RemoveFromRoleAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnUsers()
        {
            Mock<UserManager<ApplicationUser>> userManagerMock = GetUserManagerMock();
            Mock<RoleManager<IdentityRole<Guid>>> roleManagerMock = GetRoleManagerMock();

            List<ApplicationUser> users = new List<ApplicationUser>
            {
                new ApplicationUser { Id = Guid.NewGuid(), Email = "a@test.com" },
                new ApplicationUser { Id = Guid.NewGuid(), Email = "b@test.com" }
            };

            userManagerMock.Setup(u => u.Users).Returns(users.AsQueryable());
            userManagerMock.Setup(u => u.GetRolesAsync(It.IsAny<ApplicationUser>()))
                .ReturnsAsync(new List<string> { "User" });

            UserService service = new UserService(userManagerMock.Object, roleManagerMock.Object);

            IEnumerable<AdminManageUserViewModel> result = await service.GetAllAsync();

            result.Should().HaveCount(2);
        }
    }
}
