using IndustryX.ProductService.Core.Entities;
using IndustryX.ProductService.Core.Interfaces;
using IndustryX.ProductService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace IndustryX.ProductService.Infrastructure.Repositories
{
    public class ProductRepository(ProductDbContext dbContext) : IProductRepository
    {
        public async Task AddAsync(Product product)
        {
            await dbContext.Products.AddAsync(product);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var product = await dbContext.Products.FindAsync(id);
            if(product is not null)
            {
                dbContext.Products.Remove(product);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await dbContext.Products.ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await dbContext.Products.FindAsync(id);
        }

        public async Task UpdateAsync(Product product)
        {
            dbContext.Products.Update(product);
            await dbContext.SaveChangesAsync();
        }
    }
}