using System.Security.Cryptography;
class Program
{
    const int KeySize = 256;
    const int IvSize = 128; // size of IV for AES in bits
    const int SaltSize = 128; // salt size in bits
    const int Iterations = 10000; // number of iterations for PBKDF2

    static void Main(string[] args)
    {
        Console.WriteLine("Select an action:");
        Console.WriteLine("1: Encrypt file");
        Console.WriteLine("2: Decrypt file");
        var choice = Console.ReadLine();

        Console.Write("Enter the file path: ");
        var filePath = Console.ReadLine();

        Console.WriteLine("Enter your secret key: ");
        var userInputKey = Console.ReadLine();

        switch (choice)
        {
            case "1":
                Random rand = new Random();
                int randomNum = rand.Next(100, 1001);
                Console.WriteLine($"A random number {randomNum} has been added to your key.");
                var finalKey = userInputKey + randomNum.ToString();
                Encrypt(filePath, finalKey);
                break;
            case "2":
                Decrypt(filePath, userInputKey);
                break;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }

    static void Encrypt(string filePath, string finalKey)
    {
        var data = File.ReadAllBytes(filePath);
        var salt = GenerateRandomBytes(SaltSize / 8);
        var key = DeriveKey(finalKey, salt);
        var iv = GenerateRandomBytes(IvSize / 8);

        var encryptedData = EncryptData(data, key, iv);
        var combinedData = new byte[salt.Length + iv.Length + encryptedData.Length];

        Buffer.BlockCopy(salt, 0, combinedData, 0, salt.Length);
        Buffer.BlockCopy(iv, 0, combinedData, salt.Length, iv.Length);
        Buffer.BlockCopy(encryptedData, 0, combinedData, salt.Length + iv.Length, encryptedData.Length);

        var outputPath = filePath + ".enc";
        File.WriteAllBytes(outputPath, combinedData);
        Console.WriteLine($"File encrypted and saved as {outputPath}");
    }

    static void Decrypt(string filePath, string finalKey)
    {
        if (!filePath.EndsWith(".enc"))
        {
            Console.WriteLine("File doesn't seem to be encrypted.");
            return;
        }

        var combinedData = File.ReadAllBytes(filePath);
        var salt = new byte[SaltSize / 8];
        var iv = new byte[IvSize / 8];

        Buffer.BlockCopy(combinedData, 0, salt, 0, salt.Length);
        Buffer.BlockCopy(combinedData, salt.Length, iv, 0, iv.Length);

        var encryptedData = new byte[combinedData.Length - salt.Length - iv.Length];
        Buffer.BlockCopy(combinedData, salt.Length + iv.Length, encryptedData, 0, encryptedData.Length);

        var key = DeriveKey(finalKey, salt);
        var decryptedData = DecryptData(encryptedData, key, iv);

        var outputPath = filePath.Substring(0, filePath.Length - 4); // removing the ".enc" extension
        File.WriteAllBytes(outputPath, decryptedData);
        Console.WriteLine($"File decrypted and saved as {outputPath}");
    }

    static byte[] EncryptData(byte[] data, byte[] key, byte[] iv)
    {
        using var aes = Aes.Create();
        using var encryptor = aes.CreateEncryptor(key, iv);
        using var memoryStream = new MemoryStream();
        using var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
        cryptoStream.Write(data, 0, data.Length);
        return memoryStream.ToArray();
    }

    static byte[] DecryptData(byte[] data, byte[] key, byte[] iv)
    {
        using var aes = Aes.Create();
        using var decryptor = aes.CreateDecryptor(key, iv);
        using var memoryStream = new MemoryStream(data);
        using var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
        var result = new byte[data.Length];
        var bytesRead = cryptoStream.Read(result, 0, result.Length);
        return result.Take(bytesRead).ToArray();
    }

    static byte[] DeriveKey(string password, byte[] salt)
    {
        using var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, salt, Iterations);
        return rfc2898DeriveBytes.GetBytes(KeySize / 8);
    }

    static byte[] GenerateRandomBytes(int size)
    {
        var rng = new RNGCryptoServiceProvider();
        var randomBytes = new byte[size];
        rng.GetBytes(randomBytes);
        return randomBytes;
    }
}
