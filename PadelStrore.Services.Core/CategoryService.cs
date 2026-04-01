using Microsoft.EntityFrameworkCore;
using PadelStore.Data;
using PadelStore.Data.Models;
using PadelStore.ViewModels.Admin;
using PadelStrore.Services.Core.Contracts;


namespace PadelStrore.Services.Core
{
    public class CategoryService : ICategoryService
    {
        private readonly ShopDbContext context;

        public CategoryService(ShopDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<CategoryViewModel>> GetAllAsync()
        {
            return await context.Categories
                 .Select(c => new CategoryViewModel
                 {
                     Id = c.Id,
                     CategoryName = c.CategoryName
                 })
                 .ToListAsync();
        }

        public async Task CreateAsync(CategoryViewModel model)
        {
            var brand = new Category
            {
                CategoryName = model.CategoryName
            };

            await context.Categories.AddAsync(brand);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var category = await context.Categories.FindAsync(id);

            if (category != null)
            {
                context.Categories.Remove(category);
                await context.SaveChangesAsync();
            }
        }
    }
}
