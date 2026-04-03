

namespace PadelStore.ViewModels.Admin
{
    public class ProductDetailsViewModel
    {
        public Guid Id { get; set; }

        public string ProductName { get; set; } = null!;
        public string ProductDescription { get; set; } = null!;
        public decimal Price { get; set; }

        public string ImageUrl { get; set; } = null!;

        public string CategoryName { get; set; } = null!;
        public string BrandName { get; set; } = null!;

        public IEnumerable<ReviewViewModel> Reviews { get; set; }
    = new List<ReviewViewModel>();
    }
}
