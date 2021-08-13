using System;
using EzPaymentBot.Builder;
using EzPaymentBot.Dao;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace EzPaymentBot
{
    public class TelegramBot
    {
        public static string Token { get; set; } = "1943573817:AAENte2dKbUyIcSGxyUgnoEqs7da6H0m9Lo";
        public static TelegramBotClient client;

        public static ImitationDB imitationChanels = new ImitationDB();
        public static KeyBoardBuilder keyBoard = new KeyBoardBuilder();

        public TelegramBot()
        {
            client = new TelegramBotClient(Token);
        }

        public static async void OnMessageHandler(object sender, MessageEventArgs e)
        {
            var msg = e.Message;
            if (msg.Text != null)
            {
                Console.WriteLine($"Received message: {msg.Text}");
                switch (msg.Text)
                {
                    case "Каналы":
                        var chnl = await client.SendTextMessageAsync(
                            chatId: msg.Chat.Id,
                            text: imitationChanels.ShowChannels(),
                            replyToMessageId: msg.MessageId,
                            replyMarkup: keyBoard.GetMainKeyboard());
                        break;
                    ////case "Спрятать клавиатуру":
                    default:
                        await client.SendTextMessageAsync(msg.Chat.Id, "Выберете команду:", replyMarkup: keyBoard.GetMainKeyboard());
                        break;
                }
            }
        }

        public void Init()
        {
            client.StartReceiving();
            client.OnMessage += OnMessageHandler;
            Console.ReadLine();
            client.StopReceiving();
        }

        //public static IReplyMarkup GetKeyButtonBuilder()
        //{
        //    return new ReplyKeyboardMarkup
        //    {
        //        Keyboard = new List<List<KeyboardButton>>
        //        {
        //         new List<KeyboardButton> { new KeyboardButton { Text = "Каналы" }, new KeyboardButton { Text = "Подписка" } },
        //         new List<KeyboardButton> { new KeyboardButton { Text = "Инструкция" }, new KeyboardButton { Text = "Спрятать клавиатуру" } }
        //        }
        //    };
        //}


        //public async void sendMsg(Telegram.Bot.Types.Message msg)
        //{
        //    var chnl = await client.SendTextMessageAsync(
        //                   chatId: msg.Chat.Id,
        //                   text: imitationChanels.ShowChannels(),
        //                   replyToMessageId: msg.MessageId,
        //                   replyMarkup: keyboard);
        //}
    }
}
