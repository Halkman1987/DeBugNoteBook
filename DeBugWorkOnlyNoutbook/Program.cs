using System;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types.ReplyMarkups;

namespace Telegram.Bots
{
    class Program
    {
        public static class BotCredentials // Содержит Токен Бота
        {
            public static readonly string BotToken = "5275938900:AAGSYvfMIJYdrcYym_9SVxEEpfqI8sT5CMw";

        }
        static void Main(string[] args)
        {
            var bot = new BotWorker();
            bot.Initialize();
            bot.Start();
            // bot.Bot_OnMessage();

            string command;
            do
            {
                command = Console.ReadLine();
            } while (command != "stop");
            bot.Stop();
        }
        public class BotWorker
        {
            private BotMessageLogic logic;
            private ITelegramBotClient botClient;
            CancellationToken cts = new CancellationToken();
            ReceiverOptions receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = { } // receive all update types
            };
            public void Initialize()
            {
                botClient = new TelegramBotClient(BotCredentials.BotToken);
                logic = new BotMessageLogic(botClient);

            }
            public async void Start()
            {
                botClient.StartReceiving(Bot_OnMessage, HandleErrorAsync, receiverOptions, cancellationToken: cts);
            }
            async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
            {
                if (update.Type != UpdateType.Message)
                    return;
                // Only process text messages
                if (update.Message!.Type != MessageType.Text)
                    return;

                var chatId = update.Message.Chat.Id;
                var messageText = update.Message.Text;

                Console.WriteLine($"Received a '{messageText}' message in chat {chatId}.");
                Message sentMessage = await botClient.SendTextMessageAsync(
                    chatId: chatId,
                    text: "You said:\n" + messageText,
                    cancellationToken: cancellationToken);
            }
            Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
            {
                var ErrorMessage = exception switch
                {
                    ApiRequestException apiRequestException
                      => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                    _ => exception.ToString()
                };

                Console.WriteLine(ErrorMessage);
                return Task.CompletedTask;
            }
            public void Stop()
            {
                cts.ThrowIfCancellationRequested();
            }
            async Task Bot_OnMessage(ITelegramBotClient botClient, Update e, CancellationToken cancellationToken)
            {
                if (e.Message.Text != null)
                {
                    await logic.Response(e);
                }
            }
            private async Task SendTextWithKeyBoard(Conversation chat, string text, InlineKeyboardMarkup keyboard)
            {
                await botClient.SendTextMessageAsync(chatId: chat.GetId(), text: text, replyMarkup: keyboard);
            }
            private async void Bot_CallBack(object sender, CallbackQuery e)
            {
                var text = "";
                switch (e.Data)
                {
                    case "pushkin":
                        text = @"Я помню чудное мгновенье:
                                    Передо мной явилась ты,
                                    Как мимолетное виденье,
                                    Как гений чистой красоты.";
                        break;
                    case "esenin":
                        text = @"Не каждый умеет петь,
                                Не каждому дано яблоком
                                Падать к чужим ногам.";
                        break;
                    default:
                        break;
                }
                await botClient.SendTextMessageAsync(e.Message.Chat.Id, text);
                await botClient.AnswerCallbackQueryAsync(e.Id);
            }
        }
        public class BotMessageLogic // Управление логикой добавления чата
        {
            private ITelegramBotClient botClient;
            private Messanger messanger;
            private Dictionary<long, Conversation> chatList;


            public BotMessageLogic(ITelegramBotClient botClient)
            {
                messanger = new Messanger();
                chatList = new Dictionary<long, Conversation>();
                this.botClient = botClient;
            }
            public async Task Response(Update e)
            {
                var Id = e.Id;
                if (!chatList.ContainsKey(Id))
                {
                    var newchat = new Conversation(e.Message.Chat);
                    chatList.Add(Id, newchat);
                }
                var chatt = chatList[Id];
                chatt.AddMessage(e.Message);
                await SendTextMessage(chatt);
            }
            private async Task SendTextMessage(Conversation chat)
            {
                var text = messanger.CreateTextMessage(chat);
                await botClient.SendTextMessageAsync(
                chatId: chat.GetId(), text: text);
            }
        }
        public class Conversation  //Для хранения чатов ( Объект ЧАТА )
        {
            private Chat telegramChat;
            private List<Message> telegramMessages;
            public Conversation(Chat chat)
            {
                telegramChat = chat;
                telegramMessages = new List<Message>();
            }
            public void AddMessage(Message message)
            {
                telegramMessages.Add(message);
            }
            public long GetId()
            {
                var m = telegramChat.Id;
                return m;
            }
            public List<string> GetTextMessages() /// Возврат всех сообщений 
            {
                var textMessages = new List<string>();
                foreach (var message in telegramMessages)
                {
                    if (message.Text != null)
                    {
                        textMessages.Add(message.Text);
                    }
                }
                return textMessages;
            }
            public string GetLastMessage() => telegramMessages[telegramMessages.Count - 1].Text;

        }
        public class Messanger
        {
            //public string CreateTextMessage(Conversation chat)
            //{
            //    var delimiter = ",";
            //    var text = string.Join(delimiter, chat.GetTextMessages().ToArray());
            //    return text;
            //}
            public string CreateTextMessage(Conversation chat)
            {
                var text = "";
                switch (chat.GetLastMessage())
                {
                    case "/saymehi":
                        text = "привет";
                        break;
                    case "/askme":
                        text = "как дела";
                        break;
                    default:
                        var delimiter = ",";
                        text = "История ваших сообщений: " + string.Join(delimiter, chat.GetTextMessages().ToArray());
                        break;
                }
                return text;
            }
            public InlineKeyboardMarkup ReturnKeyBoard()
            {
                var buttonList = new List<InlineKeyboardButton>
                {
                     new InlineKeyboardButton
                     {
                           Text = "Пушкин",
                           CallbackData = "pushkin"
                     },

                     new InlineKeyboardButton
                     {
                         Text = "Есенин",
                         CallbackData = "esenin"
                     }
                };

                var keyboard = new InlineKeyboardMarkup(buttonList);

                return keyboard;

            }

        }
    }
}