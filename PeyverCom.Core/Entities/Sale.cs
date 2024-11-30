using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeyverCom.Core.Entities
{
    public class Sale
    {
        public int SaleID { get; set; }
        public int AuctionId { get; set; }
        public Auction Auction { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public decimal FinalPrice { get; set; }
        public DateTime SaleDate { get; set; }
        public int OfferId { get; set; }
        public Offer Offer { get; set; }
        public ICollection<CustomerSale> CustomerSales { get; set; }
    }
}
