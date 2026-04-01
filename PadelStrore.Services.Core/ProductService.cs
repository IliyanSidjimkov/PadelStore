using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PadelStore.Data;
using PadelStore.Data.Models;
using PadelStore.ViewModels.Admin;
using PadelStrore.Services.Core.Contracts;

namespace PadelStrore.Services.Core
{
    public class ProductService : IProductService
    {

        private readonly ShopDbContext  context;

        public ProductService(ShopDbContext context)
        {
            this.context = context;
        }
        public async Task CreateAsync(ProductCreateViewModel model)
        {
            Product product = new Product
            {
                ProductName = model.ProductName,
                ProductDescription = model.ProductDescription,
                Price = model.Price,
                ImageUrl = model.ImageUrl,
                CategoryId = model.CategoryId,
                BrandId = model.BrandId
            };

            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            Product? product = await context.Products.FindAsync(id);

            if (product != null)
            {
                context.Products.Remove(product);
                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ProductAllViewModel>> GetAllAsync()
        {
            return await context.Products
        .Select(p => new ProductAllViewModel
        {
            Id = p.Id,
            ImageUrl = p.ImageUrl,
            ProductName = p.ProductName,
            ProductPrice = p.Price,
            CategoryName = p.Category.CategoryName,
            BrandName = p.Brand.BrandName
        })
        .ToListAsync();
        }

        public async Task<IEnumerable<SelectListItem>> GetBrandsAsync()
        {
            return await context.Brands
            .Select(b => new SelectListItem
            {
                Value = b.Id.ToString(),
                Text = b.BrandName
            })
            .ToListAsync();
        }

        public async Task<ProductEditViewModel?> GetByIdAsync(Guid id)
        {
            Product? product = await context.Products.FindAsync(id);

            if (product == null) return null;

            return new ProductEditViewModel
            {
                Id = product.Id,
                ProductName = product.ProductName,
                ProductDescription = product.ProductDescription,
                Price = product.Price,
                ImageUrl = product.ImageUrl,
                CategoryId = product.CategoryId,
                BrandId = product.BrandId
            };
        }

        public async Task<IEnumerable<SelectListItem>> GetCategoriesAsync()
        {
            return await context.Categories
           .Select(c => new SelectListItem
           {
               Value = c.Id.ToString(),
               Text = c.CategoryName
           })
           .ToListAsync();
        }

        public async Task<ProductDetailsViewModel?> GetDetailsAsync(Guid id)
        {
            return await context.Products
        .Where(p => p.Id == id)
        .Select(p => new ProductDetailsViewModel
        {
            Id = p.Id,
            ProductName = p.ProductName,
            ProductDescription = p.ProductDescription,
            Price = p.Price,
            ImageUrl = p.ImageUrl,
            CategoryName = p.Category.CategoryName,
            BrandName = p.Brand.BrandName
        })
        .FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(ProductEditViewModel model)
        {
            Product? product = await context.Products.FindAsync(model.Id);

            if (product == null) return;

            product.ProductName = model.ProductName;
            product.ProductDescription = model.ProductDescription;
            product.Price = model.Price;
            product.ImageUrl = model.ImageUrl;
            product.CategoryId = model.CategoryId;
            product.BrandId = model.BrandId;

            await context.SaveChangesAsync();
        }
    }
}
