

namespace PadelStore.ViewModels.Admin
{
    public class ProductAllViewModel
    {
        public Guid Id { get; set; }

        public string ProductName { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public decimal ProductPrice { get; set; }

        public string CategoryName { get; set; } = null!;

        public string BrandName { get; set; } = null!;
    }
}
