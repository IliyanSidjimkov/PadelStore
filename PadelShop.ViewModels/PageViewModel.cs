

using PadelStore.ViewModels.Admin;

namespace PadelStore.ViewModels
{
    public class PageViewModel
    {
        public IEnumerable<ProductAllViewModel> Products { get; set; } = new List<ProductAllViewModel>();

        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }
    }
}
