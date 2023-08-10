using FileEncoderDecoder.Core;
using FileEncoderDecoder.UI;
using System.Runtime.InteropServices;
using System.Security;

namespace FileEncoderDecoder
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileService = new FileService();
            var encryptionService = new EncryptionService();
            var keyGeneratorService = new KeyGeneratorService();
            var consoleUI = new ConsoleUI();

            while (true)
            {
                SecureString secureUserInputKey = consoleUI.PromptForEncryptionKey();
                string userInputKey = SecureStringToString(secureUserInputKey);

                byte[] encryptionKey;
                try
                {
                    encryptionKey = keyGeneratorService.GenerateKeyFromUserInput(userInputKey);
                    secureUserInputKey.Dispose();
                }
                catch (ArgumentException ex)
                {
                    consoleUI.ShowErrorMessage(ex.Message);
                    continue;
                }
                
                int choice = consoleUI.ShowMainMenuAndGetChoice();

                if (choice == 3) // Exit
                {
                    break;
                }

                string filePath = consoleUI.PromptForFilePath();

                byte[] fileContent;
                try
                {
                    fileContent = fileService.ReadAllBytes(filePath);
                }
                catch (FileNotFoundException ex)
                {
                    consoleUI.ShowErrorMessage(ex.Message);
                    continue;
                }

                byte[] result;

                try
                {
                    if (choice == 1)
                    {
                        consoleUI.WaitingScreen();
                        result = encryptionService.Encrypt(fileContent, encryptionKey);
                        fileService.WriteAllBytes(filePath, result, true);
                    }
                    else if (choice == 2) 
                    {
                        consoleUI.WaitingScreen();
                        result = encryptionService.Decrypt(fileContent, encryptionKey);
                        fileService.WriteAllBytes(filePath, result, false);
                    }
                    else
                    {
                        consoleUI.ShowErrorMessage("Invalid choice.");
                        continue;
                    }
                }
                catch (Exception ex)
                {                    
                    consoleUI.ShowErrorMessage(ex.Message);
                    continue;
                }

                consoleUI.PauseAndClearScreen();
            }
        }

        private static string SecureStringToString(SecureString secureStr)
        {
            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(secureStr);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }
    }
}
