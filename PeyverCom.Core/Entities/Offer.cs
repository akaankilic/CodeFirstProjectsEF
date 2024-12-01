using PeyverCom.Core.Interface;

namespace PeyverCom.Core.Entities
{
    public class Offer : IEntities
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
