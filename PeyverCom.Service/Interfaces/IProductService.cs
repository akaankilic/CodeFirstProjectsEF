using PeyverCom.Core.DTO;
using PeyverCom.Core.Entities;

namespace PeyverCom.Service.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProducts();

        Task<ProductDto> GetProductById(int id);

        Task AddProduct(ProductCreateDto productDto);

        Task UpdateProduct(Product product);

        Task DeleteProduct(int id);

        Task DeleteExpiredProducts();
    }
}
