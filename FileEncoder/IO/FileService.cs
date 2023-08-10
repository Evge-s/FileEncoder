namespace FileEncoderDecoder.Core
{
    public class FileService
    {
        public byte[] ReadAllBytes(string filePath)
        {
            filePath = filePath.Trim('"');

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"File '{filePath}' was not found.");
            }

            return File.ReadAllBytes(filePath);
        }

        public void WriteAllBytes(string filePath, byte[] data, bool isEncryptionOperation)
        {
            var newFilePath = GenerateNewFilePath(filePath, isEncryptionOperation);
            File.WriteAllBytes(newFilePath, data);
            Console.WriteLine($"Operation successful! Result saved to: {newFilePath}");
        }

        private string GenerateNewFilePath(string originalPath, bool isEncryptionOperation)
        {
            string extension = Path.GetExtension(originalPath);
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(originalPath);
            string directory = Path.GetDirectoryName(originalPath);

            string suffix = isEncryptionOperation ? "_encrypted" : "_decrypted";

            return Path.Combine(directory, $"{fileNameWithoutExtension}{suffix}{extension}");
        }
    }
}
