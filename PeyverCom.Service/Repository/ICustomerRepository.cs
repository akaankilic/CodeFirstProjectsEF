using PeyverCom.Core.Entities;

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
