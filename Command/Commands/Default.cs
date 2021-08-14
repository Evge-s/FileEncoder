using System;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace EzPaymentBot.Command.Commands
{
    class Default : Command
    {
        public override string Name { get; set; } = Config.DefaultCommand;

        public override async void Execute(Message message, TelegramBotClient client)
        {
            var chnl = await client.SendTextMessageAsync(
                            chatId: message.Chat.Id,
                            text: Config.DefaultText,
                            replyToMessageId: message.MessageId,
                            replyMarkup: keyBoard.GetUserKeyboard());
        }
    }
}
