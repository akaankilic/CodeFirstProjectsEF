using PeyverCom.Core.DTO;
using PeyverCom.Core.Entities;
using PeyverCom.Core.Models;
using PeyverCom.Service.Interfaces;
using PeyverCom.Service.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeyverCom.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _productRepository.GetAllProducts();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _productRepository.GetProductById(id);
        }

        public async Task AddProduct(ProductCreateDto productDto)
        {
            var product = new Product
            {
                Name = productDto.Name,
                Description = productDto.Description,
                ProductCategoryId = productDto.ProductCategoryId,
                StartingPrice = productDto.StartingPrice,
                CustomerId = productDto.CustomerId,
                Stock = productDto.Stock,
                CategoryId = productDto.CategoryId, 
                CreatedAd = DateTime.UtcNow 
            };

            await _productRepository.AddProduct(product);
        }

        public async Task UpdateProduct(Product product)
        {
            await _productRepository.UpdateProduct(product);
        }

        public async Task DeleteProduct(int id)
        {
            await _productRepository.DeleteProduct(id);
        }

        public async Task DeleteExpiredProducts()
        {
            await _productRepository.DeleteExpiredProducts();
        }
    }
}
