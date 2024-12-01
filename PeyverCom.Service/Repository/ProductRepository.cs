using Microsoft.EntityFrameworkCore;
using PeyverCom.Core.DTO;
using PeyverCom.Core.Entities;
using PeyverCom.Data.PeyveyComDAL;

namespace PeyverCom.Service.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly PeyverComDbContext _context;

        public ProductRepository(PeyverComDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProducts()
        {
            return await _context.Products
                .Select(p => new ProductDto
                {
                    ProductId = p.ProductId,
                    Name = p.Name,
                    Description = p.Description,
                    StartingPrice = p.StartingPrice,
                    Stock = p.Stock,
                    CategoryId = p.CategoryId
                })
                .ToListAsync();
        }

        public async Task<ProductDto> GetProductById(int id)
        {
            var product = await _context.Products
                .Where(p => p.ProductId == id)
                .Select(p => new ProductDto
                {
                    ProductId = p.ProductId,
                    Name = p.Name,
                    Description = p.Description,
                    StartingPrice = p.StartingPrice,
                    Stock = p.Stock,
                    CategoryId = p.CategoryId
                })
                .FirstOrDefaultAsync();

            return product;
        }

        public async Task AddProduct(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteExpiredProducts()
        {
            var expiredProducts = await _context.Products
                .Where(p => p.CreatedAd < DateTime.UtcNow.AddDays(-7)) 
                .ToListAsync();

            _context.Products.RemoveRange(expiredProducts);
            await _context.SaveChangesAsync();
        }
    }
}
