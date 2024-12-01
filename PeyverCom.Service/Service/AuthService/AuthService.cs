using PeyverCom.Core.DTO;
using PeyverCom.Core.Entities;
using PeyverCom.Core.Helper;
using PeyverCom.Core.Interfaces;
using PeyverCom.Service.Repository;

namespace PeyverCom.Service
{
    public class AuthService : IAuthService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly JWTTokenHelper _jwtTokenHelper;

        public AuthService(ICustomerRepository customerRepository, IPasswordHasher passwordHasher, JWTTokenHelper jwtTokenHelper)
        {
            _customerRepository = customerRepository;
            _passwordHasher = passwordHasher;
            _jwtTokenHelper = jwtTokenHelper;
        }

        public async Task<string> RegisterAsync(CustomerRegisterDto registerDto)
        {
            if (await _customerRepository.EmailExistsAsync(registerDto.Email))
            {
                throw new Exception("Email is already in use.");
            }

            var hashedPassword = _passwordHasher.HashPassword(registerDto.Password, out var salt);
            var newCustomer = new Customer
            {
                Email = registerDto.Email,
                PasswordHash = hashedPassword,
                PasswordSalt = salt,
                Name = registerDto.Name,
                SurName = registerDto.SurName,
                PhoneNumber = registerDto.PhoneNumber,
                City = registerDto.City,
                Address = registerDto.Address,
            };

            await _customerRepository.AddCustomerAsync(newCustomer);

            return "Customer registered successfully";
        }

        public async Task<string> LoginAsync(CustomerLoginDto loginDto)
        {
            var customer = await _customerRepository.GetCustomerByEmailAsync(loginDto.Email);

            if (customer == null || !_passwordHasher.VerifyPassword(customer.PasswordHash, customer.PasswordSalt, loginDto.Password))
            {
                throw new UnauthorizedAccessException("Invalid credentials.");
            }

            var token = _jwtTokenHelper.GenerateToken(customer.CustomerId.ToString());
            return token;
        }
    }
}
