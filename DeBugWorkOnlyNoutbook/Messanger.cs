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
    public class Messanger // Ответ для пользователя
    {
        private CommandParser parser;
        //public string CreateTextMessage(Conversation chat)
        //{
        //    var delimiter = ",";
        //    var text = string.Join(delimiter, chat.GetTextMessages().ToArray());
        //    return text;
        //}
        public string CreateTextMessage(Conversation chat) // метод создания ответа для пользователя 
        {
            var text = "";
            switch (chat.GetLastMessage()) // получаем последнее сообщение и читаем его , в зависимости от содержания выводим кейсы
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
        public async Task MakeAnswer(Conversation chat)
        {
            var lastmess = chat.GetLastMessage();
            if (parser.IsTextCommand(lastmess))
            {
                await ExeсCommand(chat, lastmess);
            }
            else
            {
                var text = CreateTextMessage(chat);
                await SendText(chat, text);
            }
        }
        
        public void ExeсCommand(Conversation chat,string lastmess)
        {

        }
        public string CreateTextMess(Conversation chat) // метод создания ответа для пользователя 
        {
            var delimiter = ",";
            var text = "История ваших сообщений: " + string.Join(delimiter, chat.GetTextMessages().ToArray());
           
            return text;
        }
    }
}
