using Telegram.Bot;
using Telegram.Bot.Types;

namespace EzPaymentBot.Command.Commands
{
    class GetChannels : Command
    {
        public override string Name { get; set; } = Config.ShowChannels;

        public override async void Execute(Message message, TelegramBotClient client)
        {
            var chnl = await client.SendTextMessageAsync(
                            chatId: message.Chat.Id,
                            text: imitationChanels.ShowChannels(),
                            replyToMessageId: message.MessageId,
                            replyMarkup: keyBoard.GetUserKeyboard());
        }
    }
}
