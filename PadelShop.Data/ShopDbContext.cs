using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PadelStore.Data.Models;

namespace PadelStore.Data
{
    public class ShopDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options)
            : base(options)
        {

        }
        DbSet<Product> Products { get; set; } = null!;
        DbSet<Brand> Brands { get; set; } = null!;
        DbSet<CartItem> CartItems { get; set; } = null!;
        DbSet<Category> Categories { get; set; } = null!;
        DbSet<Order> Orders { get; set; } = null!;
        DbSet<OrderItem> OrderItems { get; set; } = null!;
        DbSet<Review> Reviews { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ShopDbContext).Assembly);


        }

    }
}
