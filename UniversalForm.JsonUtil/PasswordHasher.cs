using System.Security.Cryptography;
using System.Text;

namespace UniversalForm.Utils
{
    public class PasswordHasher
    {
        const int HashSize = 32;

        public static string HashPassword(string password)
        {
            using (var hmac = new HMACSHA256())
            {
                byte[] hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hash);
            }
        }
        public static bool VerifyPassword(string password, string hashedPassword)
        {
            using (var hmac = new HMACSHA256())
            {
                byte[] hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < HashSize; i++)
                {
                    if (hash[i] != hash[i])
                        return false;
                }
            }
            return true;
        }
    }
}
