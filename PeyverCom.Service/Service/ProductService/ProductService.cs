using PeyverCom.Core.DTO;
using PeyverCom.Core.Entities;
using PeyverCom.Service.Interfaces;
using PeyverCom.Service.Repository;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PeyverCom.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProducts()
        {
            var products = await _productRepository.GetAllProducts();
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<ProductDto> GetProductById(int id)
        {
            var product = await _productRepository.GetProductById(id);
            return product == null ? null : _mapper.Map<ProductDto>(product);
        }

        public async Task AddProduct(ProductCreateDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            product.CreatedAd = DateTime.UtcNow;

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
