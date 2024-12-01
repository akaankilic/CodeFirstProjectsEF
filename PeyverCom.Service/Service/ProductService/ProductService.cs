using Microsoft.EntityFrameworkCore;
using PeyverCom.Core.Entities;
using PeyverCom.Data.PeyveyComDAL;
using PeyverCom.Service.Interfaces;

namespace PeyverCom.Service
{
    public class ProductService : IProductService
    {
        private readonly PeyverComDbContext _context;

        public ProductService(PeyverComDbContext context)
        {
            _context = context;
        }

        public async Task AddProduct(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            product.CreatedAd = DateTime.Now;  
            await _context.Products.AddAsync(product); 
            await _context.SaveChangesAsync();  
        }

        public async Task UpdateProduct(Product updatedProduct)
        {
            var product = await _context.Products.FindAsync(updatedProduct.ProductId); 
            if (product == null)
                throw new KeyNotFoundException("Ürün bulunamadı.");

            product.Name = updatedProduct.Name;
            product.Description = updatedProduct.Description;
            product.StartingPrice = updatedProduct.StartingPrice;
            product.Stock = updatedProduct.Stock;
            product.CategoryId = updatedProduct.CategoryId;
            product.CustomerId = updatedProduct.CustomerId;

            _context.Products.Update(product);  
            await _context.SaveChangesAsync();  
        }

        public async Task DeleteProduct(int productId)
        {
            var product = await _context.Products.FindAsync(productId); 
            if (product == null)
                throw new KeyNotFoundException("Ürün bulunamadı.");

            _context.Products.Remove(product); 
            await _context.SaveChangesAsync(); 
        }

        public async Task<Product?> GetProductById(int productId)
        {
            return await _context.Products
                .Include(p => p.Customer)
                .Include(p => p.Category)  
                .FirstOrDefaultAsync(p => p.ProductId == productId);
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _context.Products
                .Include(p => p.Customer)
                .Include(p => p.Category)
                .ToListAsync();
        }

        public async Task DeleteExpiredProducts()
        {
            var oneWeekAgo = DateTime.Now.AddDays(-7); 
            var expiredProducts = await _context.Products
                .Where(p => p.CreatedAd <= oneWeekAgo)
                .ToListAsync(); 

            if (expiredProducts.Any())
            {
                _context.Products.RemoveRange(expiredProducts);  
                await _context.SaveChangesAsync();  
            }
        }
    }
}
