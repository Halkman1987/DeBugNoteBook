﻿using System;
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
}