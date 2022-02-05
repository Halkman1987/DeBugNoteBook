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
    class Program
    {
        static void Main(string[] args)
        {
            var bot = new BotWorker();
            bot.Initialize();
            bot.Start();
            
            string command;
            do
            {
                command = Console.ReadLine();
            } while (command != "stop");
            bot.Stop();
        }
    }
}