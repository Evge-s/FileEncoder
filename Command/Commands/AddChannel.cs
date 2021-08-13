using System;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace EzPaymentBot.Command.Commands
{
    class AddChannel : Command
    {
        public override string Name { get; set; } = Config.AddNewChannel;

        public override async void Execute(Message message, TelegramBotClient client)
        {
            string name = string.Empty;
            string link = string.Empty;
            var answn = client.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: "Input channel name:\n");
            client.GetUpdatesAsync();
            name = message.Text;
            Console.WriteLine($"name == {name}\n");
            var answl = client.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: "Input channel link:\n");
            link = message.Text;
            Console.WriteLine($"name == {link}\n");
            //await client.SendTextMessageAsync(message.Chat.Id, "Выберете команду:", replyMarkup: keyBoard.GetUserKeyboard());
        }
    }
}
