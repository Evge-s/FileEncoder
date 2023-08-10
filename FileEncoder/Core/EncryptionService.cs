using System.Security.Cryptography;

namespace FileEncoderDecoder.Core
{
    public class EncryptionService
    {
        public byte[] Encrypt(byte[] clearData, byte[] encryptionKey)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = encryptionKey;
                aes.GenerateIV();

                using (MemoryStream ms = new MemoryStream())
                {
                    ms.Write(aes.IV, 0, aes.IV.Length);

                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearData, 0, clearData.Length);
                        cs.Close();
                    }
                    return ms.ToArray();
                }
            }
        }

        public byte[] Decrypt(byte[] encryptedData, byte[] encryptionKey)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = encryptionKey;

                byte[] iv = new byte[16];
                Array.Copy(encryptedData, 0, iv, 0, iv.Length);
                aes.IV = iv;

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(encryptedData, iv.Length, encryptedData.Length - iv.Length);
                        cs.Close();
                    }
                    return ms.ToArray();
                }
            }
        }
    }
}
