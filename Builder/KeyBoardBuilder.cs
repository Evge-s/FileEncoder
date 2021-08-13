using Telegram.Bot.Types.ReplyMarkups;

namespace EzPaymentBot.Builder
{
    public class KeyBoardBuilder
    {
        private KeyButtonBuilder keys = new KeyButtonBuilder();

        public IReplyMarkup GetMainKeyboard()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = keys.GetMainKeyboardKeys()
            };
        }
    }
}
