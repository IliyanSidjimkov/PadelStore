namespace PadelStore.ViewModels
{
    public class OrderItemViewModel
    {
        public string ProductName { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
