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
            Task AddProduct(Product product);              
            Task UpdateProduct(Product product);        
            Task DeleteProduct(int productId);              
            Task<Product?> GetProductById(int productId);     
            Task<IEnumerable<Product>> GetAllProducts();     
            Task DeleteExpiredProducts();                    
        }
}
