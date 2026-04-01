

namespace PadelStore.ViewModels.Admin
{
    public class OrderViewModel
    {
        public Guid Id { get; set; }

        public string UserEmail { get; set; } = null!;

        public decimal TotalPrice { get; set; }

        public DateTime CreatedOn { get; set; }
        public string Status { get; set; } = null!;
    }
}
