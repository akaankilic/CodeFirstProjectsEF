using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeyverCom.Core.Entities
{
    public class Offer
    {
        public int OfferId { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedDate { get; set; }
        public int AuctionId { get; set; }
        public Auction Auction { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
