using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PeyverCom.Core.Helper
{
    public class JWTTokenHelper
    {
        private readonly string _secretKey;
        private readonly string _issuer;
        private readonly string _audience;
        private readonly int _tokenExpiryInHours;

        public JWTTokenHelper(IConfiguration configuration)
        {
            _secretKey = configuration["JwtSettings:SecretKey"];
            _issuer = configuration["JwtSettings:Issuer"];
            _audience = configuration["JwtSettings:Audience"];
            _tokenExpiryInHours = int.TryParse(configuration["JwtSettings:TokenExpiryInHours"], out int tokenExpiry)
                                  ? tokenExpiry
                                  : 1; 
        }

        public string GenerateToken(string customerId)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, customerId),  
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())  
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey)); 
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256); 

            var token = new JwtSecurityToken(
                issuer: _issuer,  
                audience: _audience, 
                claims: claims,  
                expires: DateTime.Now.AddHours(_tokenExpiryInHours),
                signingCredentials: creds);  

            return new JwtSecurityTokenHandler().WriteToken(token);  
        }

        public ClaimsPrincipal ValidateToken(string token)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = _issuer, 
                ValidateAudience = true,
                ValidAudience = _audience,
                ValidateLifetime = true, 
                IssuerSigningKey = key 
            };

            try
            {
                var principal = tokenHandler.ValidateToken(token, validationParameters, out _);
                return principal;
            }
            catch (SecurityTokenException)
            {
                return null; 
            }
        }
    }
}
