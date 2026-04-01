
using System.ComponentModel.DataAnnotations;


namespace PadelStore.ViewModels.Admin
{
    using static PadelStore.GCommon.ViewModelValidation.Brand;
    public class BrandViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(BrandNameMaxLength)]
        [MinLength(BrandNameMinLength)]
        public string Brand { get; set; } = null!;

        
    }
}
