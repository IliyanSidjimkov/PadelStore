
using System.ComponentModel.DataAnnotations;


namespace PadelStore.ViewModels.Admin
{
    using static PadelStore.GCommon.ViewModelValidation.Category;
    public class CategoryViewModel
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(CategoryNameMaxLength)]
        [MinLength(CategoryNameMinLength)]
        public string CategoryName { get; set; } =null!;
    }
}
