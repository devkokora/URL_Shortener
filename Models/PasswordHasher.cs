using System.Security.Cryptography;
using System.Text;
using System.Text.Unicode;

namespace URL_Shortener.Models
{
    public static class PasswordHasher
    {
        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder stringBuilder = new();
                foreach (var hashedByte in hashedBytes)
                {
                    stringBuilder.Append(hashedByte.ToString("x2"));
                }
                return stringBuilder.ToString();
            }
        }
        public static bool VerifyPassword(string password, string hashedPassword)
        {
            var hashedInput = HashPassword(password);
            return hashedInput == hashedPassword;
        }
    }
}
