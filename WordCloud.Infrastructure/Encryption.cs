using System;
using System.Security.Cryptography;
using System.Text;

namespace WordCloud.Infrastructure
{
    public static class Encryption
    {
        /// <summary>
        /// Returns a salted hashed string
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string GenerateSaltedHash(string input)
        {
            // Create a 10 char salt and use it to return a 256 salted hash
            return GenerateSHA256Hash(input, CreateSalt(10));
        }

        /// <summary>
        /// Returns a base64 representation of a random values
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        private static string CreateSalt(int size)
        {
            var random = new RNGCryptoServiceProvider();
            var buff = new byte[size];
            random.GetBytes(buff); // fill the byte array with random values
            return Convert.ToBase64String(buff);
        }

        /// <summary>
        /// Generates a hash
        /// </summary>
        /// <param name="input"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        private static string GenerateSHA256Hash(string input, string salt)
        {
            var bytes = Encoding.UTF8.GetBytes(string.Concat(input, salt));
            var hash = new SHA256Managed().ComputeHash(bytes);
            return BitConverter.ToString(hash).Replace("-", string.Empty); // make it a bit better to read
        }
    }
}