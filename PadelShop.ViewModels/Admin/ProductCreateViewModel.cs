
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;



namespace PadelStore.ViewModels.Admin
{
    using static PadelStore.GCommon.ViewModelValidation.Product;
    public class ProductCreateViewModel
    {
        [Required]
        [MaxLength(ProductNameMaxLength)]
        [MinLength(ProductNameMinLength)]
        public string ProductName { get; set; } = null!;
        [Required]
        [MaxLength(ProductDescriptionMaxLength)]
        [MinLength(ProductDescriptionMinLength)]
        public string ProductDescription { get; set; } = null!;
        [Required]
        [Range(minPrice, maxPrice)]
        public decimal Price { get; set; }

        [Required]
        [Url]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public Guid CategoryId { get; set; }

        [Required]
        public Guid BrandId { get; set; }

        
        public IEnumerable<SelectListItem> Categories { get; set; } = new List<SelectListItem>();
        public IEnumerable<SelectListItem> Brands { get; set; } = new List<SelectListItem>();
    }
}
