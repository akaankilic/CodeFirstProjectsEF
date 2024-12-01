using PeyverCom.Core.Interface;

namespace PeyverCom.Core.Entities
{
    public class Auction :IEntities
    {
        public int AuctionID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int ProductId {  get; set; }
        public Product Product { get; set; }
        public ICollection<Offer> Offers { get; set; }
        public ICollection<Sale> Sales { get; set; }

    }
}
