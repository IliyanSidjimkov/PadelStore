
using System.ComponentModel.DataAnnotations;
namespace PadelStore.Data.Models
{
    using static Common.EntityValidation.Brand;
    public class Brand
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(BrandNameMaxLength)]
        public string BrandName { get; set; } = null!;

        public virtual ICollection<Product> Products { get; set; } 
            = new List<Product>();

    }
}
