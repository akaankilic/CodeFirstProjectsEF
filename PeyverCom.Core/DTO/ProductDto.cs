namespace PeyverCom.Core.DTO
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal StartingPrice { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
    }
}
