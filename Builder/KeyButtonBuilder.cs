using System.Collections.Generic;
using Telegram.Bot.Types.ReplyMarkups;

namespace EzPaymentBot.Builder
{
    public class KeyButtonBuilder
    {
        public List<List<KeyboardButton>> Keys { get; set; }

        public List<List<KeyboardButton>> GetMainKeyboardKeys()
        {
            return new List<List<KeyboardButton>>
            {
                 new List<KeyboardButton> { new KeyboardButton { Text = "Каналы" }, new KeyboardButton { Text = "Подписка" } },
                 new List<KeyboardButton> { new KeyboardButton { Text = "Инструкция" }, new KeyboardButton { Text = "Спрятать клавиатуру" } }
            };
        }
    }
}
