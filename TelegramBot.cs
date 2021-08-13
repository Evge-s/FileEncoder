using System;
using System.Collections.Generic;
using EzPaymentBot.Command.Commands;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace EzPaymentBot
{
    public class TelegramBot
    {
        private static TelegramBotClient client;
        private static List<Command.Command> commands;

        public TelegramBot()
        {
            client = new TelegramBotClient(Config.Token);

            commands = new List<Command.Command>();
            commands.Add(new GetChannels());
            commands.Add(new AddChannel());

            client.StartReceiving();
            client.OnMessage += OnMessageHandler;
            Console.WriteLine("[Log]: Bot started");
            Console.ReadLine();
            client.StopReceiving();
        }

        public static async void OnMessageHandler(object sender, MessageEventArgs e)
        {
            var msg = e.Message;
            if (msg.Text != null)
            {
                Console.WriteLine($"Received message: {msg.From.Id} + {msg.From.Username}: \n{msg.Text}");                

                foreach(var command in commands)
                {
                    if (command.Contains(msg.Text))
                        command.Execute(msg, client);
                }
            }

        }
    }
}
