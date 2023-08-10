using System.Security;

namespace FileEncoderDecoder.UI
{
    public class ConsoleUI
    {
        public SecureString PromptForEncryptionKey()
        {
            Console.WriteLine("Enter your encryption key (up to 32 characters):");
            SecureString secureStr = new SecureString();
            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);
                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    break;
                }
                if (keyInfo.Key == ConsoleKey.Backspace)
                {
                    if (secureStr.Length > 0)
                    {
                        secureStr.RemoveAt(secureStr.Length - 1);
                        Console.Write("\b \b");
                    }
                    continue;
                }
                secureStr.AppendChar(keyInfo.KeyChar);
                Console.Write("*");
            }
            secureStr.MakeReadOnly();
            return secureStr;
        }

        public int ShowMainMenuAndGetChoice()
        {
            Console.WriteLine("Choose an operation:");
            Console.WriteLine("1. Encrypt file");
            Console.WriteLine("2. Decrypt file");
            Console.WriteLine("3. Exit");
            int.TryParse(Console.ReadLine(), out int choice);
            return choice;
        }

        public string PromptForFilePath()
        {
            Console.WriteLine("Enter the file path:");
            return Console.ReadLine();
        }

        public void ShowErrorMessage(string message)
        {
            Console.WriteLine($"An error occurred: {message}");
        }


        public void ShowInvalidPassErrorMessage(string message)
        {
            Console.WriteLine($"Invalid password code or:");
            ShowErrorMessage(message);
        }

        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void PauseAndClearScreen()
        {
            Console.WriteLine("\nPress any key to return to the main menu...");
            Console.ReadKey();
            Console.Clear();
        }

        public void ShowLoadingIndicator(string message)
        {
            char[] spinner = new char[] { '|', '/', '-', '\\' };
            int spinnerIndex = 0;

            Console.Write(message);

            while (true)
            {
                Console.Write(spinner[spinnerIndex]);
                spinnerIndex = (spinnerIndex + 1) % spinner.Length;
                Thread.Sleep(100);
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
            }
        }
    }
}
