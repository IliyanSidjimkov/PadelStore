

using System.ComponentModel.DataAnnotations;

namespace PadelStore.ViewModels
{
    using static PadelStore.GCommon.ViewModelValidation.Review;
    public class ReviewCreateViewModel
    {
        public Guid ProductId { get; set; }

        [Required]
        [MinLength(ReviewCommentMinLenght)]
        [MaxLength(ReviewCommentMaxLenght)]
        public string Comment { get; set; } = null!;

        [Range(1, 5)]
        public int Rating { get; set; }
    }
}
