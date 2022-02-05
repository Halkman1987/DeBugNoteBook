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

    }
}
