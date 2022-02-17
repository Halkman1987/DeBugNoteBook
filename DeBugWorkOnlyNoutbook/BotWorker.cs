using System;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types.ReplyMarkups;

namespace DeBugWorkOnlyNoutbook
{
    public class BotWorker
    {
        private ITelegramBotClient botClient;
        private BotMessageLogic logic;

        CancellationToken cts = new CancellationToken();
        ReceiverOptions receiverOptions = new ReceiverOptions
        {
            AllowedUpdates = { }
        };
        public void Initialize()// Создание объекта бота
        {
            botClient = new TelegramBotClient(BotCredentials.BotToken);
            logic = new BotMessageLogic(botClient);
        }
        public async void Start() // Старт бота
        {
            // Передаем методы для принятия сообщений , обработке исключений , прааметр обновлений и токен завершения
            botClient.StartReceiving(Bot_OnMessage, HandleErrorAsync, receiverOptions, cancellationToken: cts);
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
        public void Stop() //Остановка бота
        {
            cts.ThrowIfCancellationRequested();
        }

        // Асинхронный метод для получния сообщений
        async Task Bot_OnMessageMy(ITelegramBotClient botClient, Update e, CancellationToken cancellationToken)
        {
            if (e.Message.Text != null)
            {
                await logic.Response(e); // передаем сообщение в метод Респонз для дальнейшей обработки
            }
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
        async Task Bot_OnMessage(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if (update.CallbackQuery != null)
            {
                await Bot_Callback(new object(), update);
            }
            if (update.Type != UpdateType.Message)
                return;
            if (update.Message!.Type != MessageType.Text)
                return;
            await logic.Response(update);
        }
        async Task Bot_Callback(object sender, Update e)
        {
            var text = "";
            switch (e.CallbackQuery.Data)
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
            await botClient.SendTextMessageAsync(e.CallbackQuery.Message.Chat.Id, text);
            await botClient.AnswerCallbackQueryAsync(e.CallbackQuery.Id);
        }
    }
}
