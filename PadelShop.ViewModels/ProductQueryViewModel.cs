

using Microsoft.AspNetCore.Mvc.Rendering;
using PadelStore.ViewModels.Admin;

namespace PadelStore.ViewModels
{
    public class ProductQueryViewModel
    {
        public string? SearchTerm { get; set; }

        public Guid? CategoryId { get; set; }

        public Guid? BrandId { get; set; }

        public int CurrentPage { get; set; } = 1;

        public int TotalPages { get; set; }

        public IEnumerable<ProductAllViewModel> Products { get; set; } = new List<ProductAllViewModel>();

        public IEnumerable<SelectListItem> Categories { get; set; } = new List<SelectListItem>();

        public IEnumerable<SelectListItem> Brands { get; set; } = new List<SelectListItem>();
    }
}
