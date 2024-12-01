using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeyverCom.Core.DTO
{
    public class ProductCreateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ProductCategoryId { get; set; }
        public decimal StartingPrice { get; set; }
        public int CustomerId { get; set; } 
        public int Stock { get; set; }
        public int CategoryId { get; set; } 
    }
}
