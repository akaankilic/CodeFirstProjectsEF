using PeyverCom.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeyverCom.Core.Entities
{
    public class CustomerSale : IEntities
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int SaleId { get; set; } 
        public Sale Sale { get; set; }
        public decimal SaleAmount { get; set; }
    }
}
