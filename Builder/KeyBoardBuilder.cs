using Telegram.Bot.Types.ReplyMarkups;

namespace EzPaymentBot.Builder
{
    public class KeyBoardBuilder
    {
        private KeyButtonBuilder keys = new KeyButtonBuilder();
        public IReplyMarkup GetAdminKeyboard()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = keys.GetAdminKeys()
            };
        }

        public IReplyMarkup GetUserKeyboard()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = keys.GetUserKeys()
            };
        }
    }
}
