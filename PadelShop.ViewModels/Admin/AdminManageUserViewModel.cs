

namespace PadelStore.ViewModels.Admin
{
    public class AdminManageUserViewModel
    {
        public Guid Id { get; set; }

        public string Email { get; set; } = null!;

        public IEnumerable<string> Roles { get; set; } = new List<string>();
    }
}
