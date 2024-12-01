using Microsoft.AspNetCore.Mvc;
using PeyverCom.Core.Entities;
using PeyverCom.Service;
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

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            var products = await _productService.GetAllProducts();
            return Ok(products); 
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var product = await _productService.GetProductById(id);

            if (product == null)
            {
                return NotFound(); 
            }

            return Ok(product); 
        }

        [HttpPost]
        public async Task<ActionResult<Product>> AddProduct(Product product)
        {
            if (product == null)
            {
                return BadRequest("Ürün verisi boş olamaz."); 
            }

            await _productService.AddProduct(product);

            return CreatedAtAction(nameof(GetProductById), new { id = product.ProductId }, product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, Product product)
        {
            if (id != product.ProductId)
            {
                return BadRequest("Ürün ID'si uyumsuz.");  
            }

            try
            {
                await _productService.UpdateProduct(product);
            }
            catch (KeyNotFoundException)
            {
                return NotFound(); 
            }

            return NoContent(); 
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                await _productService.DeleteProduct(id);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();  
            }

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
