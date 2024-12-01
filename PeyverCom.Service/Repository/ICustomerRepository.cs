using PeyverCom.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeyverCom.Service.Repository
{
    public interface ICustomerRepository
    {
        Task<Customer?> GetCustomerByEmailAsync(string email);
        Task AddCustomerAsync(Customer customer);
        Task SaveChangesAsync();
        Task<bool> EmailExistsAsync(string email);
    }
}
