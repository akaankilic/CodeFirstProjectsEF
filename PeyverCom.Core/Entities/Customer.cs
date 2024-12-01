using PeyverCom.Core.Interface;

namespace PeyverCom.Core.Entities
{
    public class Customer : IEntities
    {
        public int CustomerId { get; set; }

        public string Name { get; set; }

        public string SurName { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string City { get; set; }
        public string PhoneNumber { get; set; }

        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }

        public ICollection<Product> Products { get; set; }
        public ICollection<Offer> Offers { get; set; }
        public ICollection<Sale> Sales { get; set; }
        public ICollection<CustomerSale> CustomerSales { get; set; }
        public ICollection<Message> Messages { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
