using PeyverCom.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
