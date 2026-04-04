using Microsoft.AspNetCore.Mvc.Rendering;
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
        public async Task<IEnumerable<BrandViewModel>> GetAllAsync()
        {
            return await context.Brands
                .Select(b => new BrandViewModel
                {
                    Id = b.Id,
                    Brand = b.BrandName
                })
                .ToListAsync();
        }

        public async Task CreateAsync(BrandViewModel model)
        {
            Brand brand = new Brand
            {
                BrandName = model.Brand
            };

            await context.Brands.AddAsync(brand);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            Brand? brand = await context.Brands.FindAsync(id);

            if (brand != null)
            {
                context.Brands.Remove(brand);
                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<SelectListItem>> GetBrandsAsync()
        {
            return await context.Brands
         .Select(c => new SelectListItem
         {
             Value = c.Id.ToString(),
             Text = c.BrandName
         })
         .ToListAsync();
        }
    }
}
