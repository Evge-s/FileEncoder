using System.Text;
using System.Security.Cryptography;

namespace FileEncoderDecoder.Core
{
    public class KeyGeneratorService
    {
        public byte[] GenerateKeyFromUserInput(string userInput)
        {
            if (string.IsNullOrEmpty(userInput))
            {
                throw new ArgumentException("The input key cannot be empty or null.");
            }

            if (userInput.Length > 32)
            {
                throw new ArgumentException("The input key is too long.");
            }

            using (SHA256 sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(Encoding.UTF8.GetBytes(userInput));
            }
        }
    }
}
