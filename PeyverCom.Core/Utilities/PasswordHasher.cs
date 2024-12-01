using PeyverCom.Core.Interfaces;
using System.Security.Cryptography;
using System.Text;
namespace PeyverCom.Core.Utilities
{
    public class PasswordHasher : IPasswordHasher
    {
            public string HashPassword(string password, out string salt)
            {

                salt = GenerateSalt();

                return HashWithSalt(password, salt);
            }

            public bool VerifyPassword(string storedHash, string storedSalt, string providedPassword)
            {
                var hashedProvidedPassword = HashWithSalt(providedPassword, storedSalt);
                return storedHash == hashedProvidedPassword;
            }

            private string GenerateSalt()
            {
                using (var rng = new RNGCryptoServiceProvider())
                {
                    byte[] saltBytes = new byte[32]; 
                    rng.GetBytes(saltBytes);
                    return Convert.ToBase64String(saltBytes);
                }
            }

            private string HashWithSalt(string password, string salt)
            {
                byte[] saltBytes = Convert.FromBase64String(salt);

                using (var pbkdf2 = new Rfc2898DeriveBytes(password, saltBytes, 10000, HashAlgorithmName.SHA256))
                {
                    byte[] hashBytes = pbkdf2.GetBytes(32); 
                    return Convert.ToBase64String(hashBytes);
                }
            }
        }
    }