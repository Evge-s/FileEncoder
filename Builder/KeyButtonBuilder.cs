using System.Collections.Generic;
using Telegram.Bot.Types.ReplyMarkups;

namespace EzPaymentBot.Builder
{
    public class KeyButtonBuilder
    {
        public List<List<KeyboardButton>> Keys { get; set; }

        public List<List<KeyboardButton>> GetAdminKeys()
        {
            return new List<List<KeyboardButton>>
            {
                new List<KeyboardButton> { new KeyboardButton { Text = "Каналы" }, new KeyboardButton { Text = "Добавить канал" } },
                new List<KeyboardButton> { new KeyboardButton { Text = "admin" }, new KeyboardButton { Text = "test" } }
            };
        }

        public List<List<KeyboardButton>> GetUserKeys()
        {
            return new List<List<KeyboardButton>>
            {
                new List<KeyboardButton> { new KeyboardButton { Text = "Каналы" }, new KeyboardButton { Text = "Подписка" } },
                new List<KeyboardButton> { new KeyboardButton { Text = "Инструкция" }, new KeyboardButton { Text = "user" } }
            };
        }
    }
}
