

using System.ComponentModel.DataAnnotations;

namespace PadelStore.Data.Models
{
    using static Common.EntityValidation.Category;
    public class Category
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(CategoryNameMaxLength)]
        public string CategoryName { get; set; } = null!;


        public virtual ICollection<Product> Products { get; set; } 
            = new List<Product>();
    }
}
