using System;
using System.IO;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Extensions.Polling;

namespace Telegram.Bots
{
    class Program
    {
        static ITelegramBotClient botClient;
        static void Main(string[] args)
        {
            var bot = new BotWorker();
            bot.Initialize();

            var me = botClient.GetMeAsync().Result;
            Console.WriteLine($" Hello my name is {me.FirstName}");

            //botClient.OnMessage += Bot_OnMessage;
            //botClient.StartReceiving();
            //Console.WriteLine("Нажмите любую кнопку для остановки");
            //Console.ReadKey();
            //botClient.StopReceiving();




        }

        public static class BotCredentials
        {
            public static readonly string BotToken = "5275938900:AAGSYvfMIJYdrcYym_9SVxEEpfqI8sT5CMw";

        }
        public class BotWorker
        {
            ReceiverOptions receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = { } // receive all update types
            };
            public void Initialize()
            {
                botClient = new TelegramBotClient(BotCredentials.BotToken);
            }
            public void Start()
            {
                botClient.StartReceiving(receiverOptions);
            }
            public void Stop()
            {
                botClient.StopMessageLiveLocationAsync();
            }
            static async void Bot_OnMessage(object sender, MessageEventArgs e)
            {
                if (e.Message.Text != null)
                {
                    Console.WriteLine($"Полученно сообщение в чате : {e.Message.Chat.Id}");
                    await botClient.SendTextMessageAsync(
                   chatId: e.Message.Chat, text: "Вы написали :\n" + e.Message.Text);
                }
            }
        }
    }

}