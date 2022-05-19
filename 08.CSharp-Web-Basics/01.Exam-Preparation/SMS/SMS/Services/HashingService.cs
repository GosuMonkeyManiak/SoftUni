namespace SMS.Services
{
    using System.Security.Cryptography;
    using System.Text;
    using Contracts;

    public class HashingService : IHashingService
    {
        public string HashPassword(string password)
        {
            using var sha256Hash = SHA256.Create();
            
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
            
            var builder = new StringBuilder();

            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }

            return builder.ToString();
        }
    }
}
