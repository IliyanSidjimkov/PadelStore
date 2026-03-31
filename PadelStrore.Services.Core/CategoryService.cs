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
        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await context.Categories.ToListAsync();
        }

        public async Task CreateAsync(string name)
        {
            var category = new Category
            {
                CategoryName = name
            };

            await context.Categories.AddAsync(category);
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
