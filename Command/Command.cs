using EzPaymentBot.Builder;
using EzPaymentBot.Dao;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace EzPaymentBot.Command
{
    public abstract class Command
    {
        public abstract string Name { get; set; }

        public static ImitationDB imitationChanels = new ImitationDB();
        public static KeyBoardBuilder keyBoard = new KeyBoardBuilder();

        public abstract void Execute(Message message, TelegramBotClient client);

        public bool Contains(string message)
        {
            if (message.Equals(Name))
                return true;
            return false;
        }
    }
}
