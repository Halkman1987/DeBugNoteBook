using System;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types.ReplyMarkups;

namespace DeBugWorkOnlyNoutbook.Commands
{
    public class PoemButton:AbstractCommand,IKeyboardCommand
    {
        public PoemButton()
        {
            CommandText = "/poem";
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
