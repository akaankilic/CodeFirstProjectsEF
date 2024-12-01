using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PeyverCom.Core.DTO;
using PeyverCom.Core.Entities;
using PeyverCom.Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PeyverCom.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllProducts()
        {
            var products = await _productService.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProductById(int id)
        {
            var product = await _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost("add")]
        public async Task<ActionResult> AddProduct([FromBody] ProductCreateDto productDto)
        {
            if (productDto == null)
            {
                return BadRequest("Ürün verisi boş olamaz.");
            }

            await _productService.AddProduct(productDto);
            return StatusCode(201); 
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateProduct(int id, Product product)
        {
            if (id != product.ProductId)
            {
                return BadRequest("Ürün ID'si uyumsuz.");
            }

            await _productService.UpdateProduct(product);
            return NoContent(); 
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productService.DeleteProduct(id);
            return NoContent();
        }

        [HttpDelete("DeleteExpired")]
        public async Task<IActionResult> DeleteExpiredProducts()
        {
            await _productService.DeleteExpiredProducts();
            return NoContent();
        }
    }
}
