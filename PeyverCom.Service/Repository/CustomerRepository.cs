using Microsoft.EntityFrameworkCore;
using PeyverCom.Core.Entities;
using PeyverCom.Data.PeyveyComDAL;

namespace PeyverCom.Service.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly PeyverComDbContext _context;

        public CustomerRepository(PeyverComDbContext context)
        {
            _context = context;
        }

        public async Task AddCustomerAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<Customer?> GetCustomerByEmailAsync(string email)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.Email == email);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<bool> EmailExistsAsync(string email)
        { 
            return await _context.Customers.AnyAsync(c => c.Email == email);
        }

    }
}
