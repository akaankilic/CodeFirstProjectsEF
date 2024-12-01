using Microsoft.AspNetCore.Mvc;
using PeyverCom.Core.DTO;
using PeyverCom.Core.Entities;
using PeyverCom.Core.Helper;
using PeyverCom.Core.Interfaces;
using PeyverCom.Service.Repository;

namespace PeyverCom.WebAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly JWTTokenHelper _jwtTokenHelper;

        public AuthController(ICustomerRepository customerRepository,IPasswordHasher passwordHasher,JWTTokenHelper jwtTokenHelper)
        {   
            _customerRepository = customerRepository;
            _passwordHasher = passwordHasher;
            _jwtTokenHelper = jwtTokenHelper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CustomerRegisterDto registerDto)
        {
            if (await _customerRepository.EmailExistsAsync(registerDto.Email))
            {
                return BadRequest("Email is already use.");
            }
            var hashedPassword = _passwordHasher.HashPassword(registerDto.Password,out var salt);
            var newCustomer = new Customer
            {
                Email = registerDto.Email,
                PasswordHash = hashedPassword,
                PasswordSalt = salt,
                Name = registerDto.Name,
                SurName= registerDto.SurName,
                PhoneNumber = registerDto.PhoneNumber,
                City = registerDto.City,
                Address = registerDto.Address,
            };

            await _customerRepository.AddCustomerAsync(newCustomer);
            return Ok("Customer registered succesfully");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]CustomerLoginDto loginDto)
        {
            var customer = await _customerRepository.GetCustomerByEmailAsync(loginDto.Email);

            if (customer == null || !_passwordHasher.VerifyPassword(customer.PasswordHash, customer.PasswordSalt, loginDto.Password))
                return Unauthorized("Invalid credentials.");

            var token = _jwtTokenHelper.GenerateToken(customer.CustomerId.ToString());

            return Ok(new { Token = token });
        }
    }
}
