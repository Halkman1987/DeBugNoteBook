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
        ITelegramBotClient botClient;
        private CommandParser parser;

        public Messanger(ITelegramBotClient botClient)
        {
            this.botClient = botClient;
            parser = new CommandParser();
            RegistrCommands();

        }
        private void RegistrCommands()
        {
            parser.AddCommands(new SayHiCommand());
            parser.AddCommands(new PoemButton(botClient));
        }
        private string CreateTextMessage()
        {
            var text = "Not a command";

            return text;
        }
        /*public string CreateTextMessage(Conversation chat) // метод создания ответа для пользователя 
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
                    text = "История ваших сообщений: " + string.Join(delimiter, chat.GetMessageText().ToArray());
                    break;
            }
            return text;
        }*/
        public async Task MakeAnswer(Conversation chat)
        {
            var lastmess = chat.GetLastMessage();
            if (parser.IsTextCommand(lastmess))
            {
                await ExeсCommand(chat, lastmess);
            }
            if (parser.IsMessageCommand(lastmess))
            {
                await ExeсCommand(chat, lastmess);
            }
            else
            {
                var text = CreateTextMessage();
                await SendText(chat, text);
            }
        }
        private async Task SendText(Conversation chat, string text)
        {
            await botClient.SendTextMessageAsync(
                  chatId: chat.GetId(),
                  text: text
                );
        }
        public async Task ExeсCommand(Conversation chat,string command)
        {
            if (parser.IsTextCommand(command))
            {
                var text = parser.GetMessageText(chat, command);

                await SendText(chat, text);
            }
        }
       /* public string CreateTextMess(Conversation chat) // метод создания ответа для пользователя 
        {
            var delimiter = ",";
            var text = "История ваших сообщений: " + string.Join(delimiter, chat.GetTextMessages().ToArray());
           
            return text;
        }*/
    }
}
