using PeyverCom.Core.DTO;

namespace PeyverCom.Core.Interfaces
{
    public interface IAuthService
    {
        Task<string> RegisterAsync(CustomerRegisterDto registerDto);
        Task<string> LoginAsync(CustomerLoginDto loginDto);
    }
}
