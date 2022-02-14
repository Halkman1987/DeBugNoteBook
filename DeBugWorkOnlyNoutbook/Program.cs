﻿using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Telegagram
{

    class Program
    {
        static void Main()
        {
           
            static int BinarySearch(int value , int[] array)
            {
                var left = array[0];
                var rigth = array.Length;
                while(left <= rigth)
                {
                    var middle = (rigth + left) / 2;
                    var midEl = array[middle];
                    if (midEl == value)
                    {
                        return middle;
                    }
                    else if (value < midEl)
                    {
                        rigth = middle - 1;
                    }
                    else
                    {
                        left = middle + 1;
                    }
                }
                return -1;
            }
            
            
            var botClient = new TelegramBotClient("{YOUR_ACCESS_TOKEN_HERE}");

            using var cts = new CancellationTokenSource();

            // StartReceiving does not block the caller thread. Receiving is done on the ThreadPool.
            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = { } // receive all update types
            };
            botClient.StartReceiving( HandleUpdateAsync, HandleErrorAsync, receiverOptions, cancellationToken: cts.Token);

            var me = await botClient.GetMeAsync();

            Console.WriteLine($"Start listening for @{me.Username}");
            Console.ReadLine();

            // Send cancellation request to stop bot
            cts.Cancel();

            async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
            {
                // Only process Message updates: https://core.telegram.org/bots/api#message
                if (update.Type != UpdateType.Message)
                    return;
                // Only process text messages
                if (update.Message!.Type != MessageType.Text)
                    return;

                var chatId = update.Message.Chat.Id;
                var messageText = update.Message.Text;

                Console.WriteLine($"Received a '{messageText}' message in chat {chatId}.");

                // Echo received message text
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
        }
    }
}
    

