using PeyverCom.Core.Interface;

namespace PeyverCom.Core.Entities
{
    public class CustomerProduct : IEntities
    {
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
    }
}
