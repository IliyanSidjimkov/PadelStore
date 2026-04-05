

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PadelStore.Data.Models
{
    using static Common.EntityValidation.Product;
    public class Product
    {

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(ProductNameMaxLength)]
        public string ProductName { get; set; } = null!;
        [Required]
        [MaxLength(ProductDescriptionMaxLength)]
        public string ProductDescription { get; set; } = null!;
        
        public decimal Price { get; set; }

        [Required]
        [Url]
        public string ImageUrl { get; set; } = null!;

        [ForeignKey(nameof(Category))]
        public Guid CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        [ForeignKey(nameof(Brand))]
        public Guid BrandId { get; set; }
        public Brand Brand { get; set; } = null!;

        public bool IsDeleted { get; set; } = false;

        public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}
