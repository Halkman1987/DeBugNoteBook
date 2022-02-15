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
    public class Conversation  //Для хранения чатов ( Объект ЧАТА )
    {
        private Chat telegramChat;
        private List<Message> telegramMessages;
        public Conversation(Chat chat) //создаем хранилку инициализируя новый Чат (Chat telegramChat)
                                       //и создав лист с сообщениями ( telegramMessages = new List<Message>())
        {
            telegramChat = chat;
            telegramMessages = new List<Message>();
        }
        public void AddMessage(Message message) //для добавления в хранилку новых сообщений
        {
            telegramMessages.Add(message);//добаляем в List<Message> telegramMessages
        }
        public long GetId()
        {
            var m = telegramChat.Id;
            return m;
        }
       
        public string GetLastMessage() => telegramMessages[^1].Text; // метод для вывода последнего сообщения в чате
        
    }
}
