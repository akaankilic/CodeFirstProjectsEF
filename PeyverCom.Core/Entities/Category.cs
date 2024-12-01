using PeyverCom.Core.Interface;

namespace PeyverCom.Core.Entities
{
    public class Category : IEntities
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
