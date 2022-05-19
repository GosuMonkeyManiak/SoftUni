namespace PetStore.Core.Utilities
{
    using System;
    using System.Security.Cryptography;
    using System.Text;

    public static class PasswordHasher
    {
        public static string Hash(string password)
        {
            SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider();

            byte[] password_bytes = Encoding.ASCII.GetBytes(password);
            byte[] encrypted_bytes = sha256.ComputeHash(password_bytes);

            return Convert.ToBase64String(encrypted_bytes);
        }
    }
}
