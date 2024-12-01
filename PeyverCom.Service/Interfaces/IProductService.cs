using PeyverCom.Core.DTO;
using PeyverCom.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeyverCom.Service.Interfaces
{

        public interface IProductService
        {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> GetProductById(int id);
        Task AddProduct(ProductCreateDto productDto);
        Task UpdateProduct(Product product);
        Task DeleteProduct(int id);
        Task DeleteExpiredProducts();
    }
}
