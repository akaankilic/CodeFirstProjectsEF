using PeyverCom.Core.DTO;
using PeyverCom.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PeyverCom.Service.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDto>> GetAllProducts();

        Task<ProductDto> GetProductById(int id);

        Task AddProduct(Product product);

        Task UpdateProduct(Product product);

        Task DeleteProduct(int id);

        Task DeleteExpiredProducts();
    }
}
