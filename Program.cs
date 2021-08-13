namespace EzPaymentBot
{
    class Program
    {
        public static void Main(string[] args)
        {
            TelegramBot bot = new TelegramBot();
            bot.Init();
        }
    }
}
