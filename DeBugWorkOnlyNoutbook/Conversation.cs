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
        public Conversation(Chat chat)
        {
            telegramChat = chat;
            telegramMessages = new List<Message>();
        }
        public void AddMessage(Message message)
        {
            telegramMessages.Add(message);
        }
        public long GetId()
        {
            var m = telegramChat.Id;
            return m;
        }
        public List<string> GetTextMessages() /// Возврат всех сообщений 
        {
            var textMessages = new List<string>();
            foreach (var message in telegramMessages)
            {
                if (message.Text != null)
                {
                    textMessages.Add(message.Text);
                }
            }
            return textMessages;
        }
        public string GetLastMessage() => telegramMessages[^1].Text; // метод для вывода последнего сообщения в чате

    }
}
