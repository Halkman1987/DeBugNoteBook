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
    public class SayHiCommand : AbstractCommand ,IChatTextCommand
    {
        ITelegramBotClient botClient;
        public SayHiCommand(ITelegramBotClient botClient)
        {
            this.botClient = botClient;
            CommandText = "/saymehi";
        }

        public string ReturnText()
        {
            return "привет";
        }
    }
}
