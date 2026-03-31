using Microsoft.EntityFrameworkCore;
using PadelStore.Data;
using PadelStore.Data.Models;
using PadelStore.ViewModels.Admin;
using PadelStrore.Services.Core.Contracts;

namespace PadelStrore.Services.Core
{
    public class BrandService : IBrandService
    {

        private readonly ShopDbContext context;

        public BrandService(ShopDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Brand>> GetAllAsync()
        {
            return await context.Brands.ToListAsync();
        }

        public async Task CreateAsync(string name)
        {
            var brand = new Brand
            {
                BrandName = name
            };

            await context.Brands.AddAsync(brand);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var brand = await context.Brands.FindAsync(id);

            if (brand != null)
            {
                context.Brands.Remove(brand);
                await context.SaveChangesAsync();
            }
        }
    }
}
