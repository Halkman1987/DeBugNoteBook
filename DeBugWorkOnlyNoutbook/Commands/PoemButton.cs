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
    public class PoemButton:AbstractCommand,IKeyboardCommand
    {
        ITelegramBotClient botClient;
        public PoemButton(ITelegramBotClient botClient)
        {
            this.botClient = botClient;
            CommandText = "/poem";
        }

        public void AddCallBack(Conversation chat)
        {
            this.botClient.AnswerCallbackQueryAsync(Bot_CallBack(,chat))  ;
        }

        public string InformationalMessage()
        {
            throw new NotImplementedException();
        }

        public InlineKeyboardMarkup ReturnKeyBoard()
        {
            var buttonList = new List<InlineKeyboardButton>
            {
                     new InlineKeyboardButton("Пушкин")
                     {
                          // Text = "Пушкин"
                          CallbackData = "pushkin"
                     },

                     new InlineKeyboardButton("Есенин")
                     {
                        // Text = "Есенин"
                         CallbackData = "esenin"
                     }
            };
            var keyboard = new InlineKeyboardMarkup(buttonList);
            return keyboard;
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
