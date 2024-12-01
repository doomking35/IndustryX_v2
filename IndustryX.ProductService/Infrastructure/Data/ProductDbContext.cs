using Microsoft.EntityFrameworkCore;
using IndustryX.ProductService.Core.Entities;

namespace IndustryX.ProductService.Infrastructure.Data
{
    public class ProductDbContext(DbContextOptions<ProductDbContext> options) : DbContext(options)
    {
        public DbSet<Product> Products { get; set; }
    }
}