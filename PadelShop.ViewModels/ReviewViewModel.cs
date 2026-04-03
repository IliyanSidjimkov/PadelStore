

namespace PadelStore.ViewModels
{
    public class ReviewViewModel
    {
        public Guid Id { get; set; }

        public string Comment { get; set; } = null!;

        public int Rating { get; set; }

        public string UserEmail { get; set; } = null!;

        public Guid UserId { get; set; }

        public Guid ProductId { get; set; }
        public string ProductName { get; set; } = null!;
    }
}
