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
}
