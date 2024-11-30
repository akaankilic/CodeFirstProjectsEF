using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeyverCom.Core.Entities
{
    public class Message
    {
        public int MessageId { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public string Content   { get; set; }
        public DateTime SendDate { get; set; }
        public Customer Sender { get; set; }
        public Customer Receiver { get; set; }
    }
}
