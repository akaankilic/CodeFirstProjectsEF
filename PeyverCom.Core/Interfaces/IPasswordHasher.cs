namespace PeyverCom.Core.Interfaces
{
    public interface IPasswordHasher 
    {
        string HashPassword(string password, out string salt);
        bool VerifyPassword(string storedHash, string storedSalt, string providedPassword);
    }
}
