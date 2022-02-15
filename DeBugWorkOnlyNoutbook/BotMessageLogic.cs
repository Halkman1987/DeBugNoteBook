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
            this.botClient = botClient;
            messanger = new Messanger(botClient);
            chatList = new Dictionary<long, Conversation>();
           
        }
        public async Task Response(Update e) // получаем обновление (новое сообщение)
        {
            var Id = e.Id;
            if (!chatList.ContainsKey(Id))//сравниваем из коллекции Чатов ид чата
            {
                var newchat = new Conversation(e.Message.Chat);// создаем новую хранилку чата с помошью класса Conversations
                                                               // где хранится сам чат 
                chatList.Add(Id, newchat);   // добавляем в  Dictionary<long, Conversation> chatList  коллекцию с чатом
            }
            // или 
            var chatt = chatList[Id]; // определяем ид чат-листа
            chatt.AddMessage(e.Message);//по ид чата добавляем сообщение в эту коллекцию 
            await SendTextMessage(chatt);// передаем ид в метод  для Ответа пользователю (самое важное) 
        }
        private async Task SendTextMessage(Conversation chatt) // метод ответа пользователю
        {
            await messanger.MakeAnswer(chatt);
           /* var text = messanger.CreateTextMess(chatt); // метод для создания сообщения пользователю
            await botClient.SendTextMessageAsync(
            chatId: chatt.GetId(), text: text);*/
        }
        
    }   
}
