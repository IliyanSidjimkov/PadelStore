

namespace PadelStore.ViewModels
{
    public class OrderDetailsViewModel
    {
        public Guid Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public decimal TotalPrice { get; set; }

        public string Status { get; set; } = null!;

        public IEnumerable<OrderItemViewModel> Items { get; set; }
            = new List<OrderItemViewModel>();
    }
}
