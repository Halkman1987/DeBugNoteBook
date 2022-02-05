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
       

    }
}
