
namespace PadelStore.Data.Seeding.Contracts
{
    public interface IIdentitySeeder
    {
        Task SeedRolesAsync();

        Task SeedAdminUserAsync();
    }
}
