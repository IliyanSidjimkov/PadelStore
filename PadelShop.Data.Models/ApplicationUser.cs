using Microsoft.AspNetCore.Identity;


namespace PadelStore.Data.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime Birthdate { get; set; }

        public virtual ICollection<Order> Orders { get; set; } = 
            new List<Order>();
        public virtual ICollection<Review> Reviews { get; set; } = 
            new List<Review>();
        public virtual ICollection<CartItem> CartItems { get; set; } = 
            new List<CartItem>();

    }
}
