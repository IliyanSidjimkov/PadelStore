

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PadelStore.Data.Models
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid UserId { get; set; } 

        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; } = null!;

        public DateTime OrderDate { get; set; } = DateTime.UtcNow;

        [Range(0, 100000)]
        public decimal TotalPrice { get; set; }

        public  virtual ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
    }
}
