using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace PeyverCom.Core.Entities
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Password { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<Offer> Offers { get; set; }

        public ICollection<Sale> Sales { get; set; }

    }
}
