using PeyverCom.Core.Interface;

namespace PeyverCom.Core.Entities
{
    public class Comment : IEntities
    {
    public int CommentId    { get; set; }
    public int CustomerId { get; set; }
    public int ProductId    { get; set; }
    public string Content { get; set; }
    public DateTime CreatedDate { get; set; }
    public Customer Customer { get; set; }
    public Product Product { get; set; }
    }
}
