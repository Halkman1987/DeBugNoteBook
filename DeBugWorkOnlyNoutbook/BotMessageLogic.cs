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
        public async Task Response(Update e) // 
        {
            var Id = e.Id;
            if (!chatList.ContainsKey(Id))//сравниваем из коллекции Чатов ид чата
            {
                var newchat = new Conversation(e.Message.Chat);//новая хранилка чата
                chatList.Add(Id, newchat);   // добавляем в нее коллекцию с чатом
            }
            var chatt = chatList[Id]; // определяем ид чат-листа
            chatt.AddMessage(e.Message);//ид чату добавляем сообщение в эту коллекцию 
            await SendTextMessage(chatt);// передаем ид в метод Ответа пользователю 
        }
        private async Task SendTextMessage(Conversation chatt) // метод ответа пользователю
        {
            var text = messanger.CreateTextMess(chatt); // метод для создания сообщения пользователю
            await botClient.SendTextMessageAsync(
            chatId: chatt.GetId(), text: text);
        }
        
    }   
}
