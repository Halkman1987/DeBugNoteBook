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
        public async Task MakeAnswer(Conversation chat)
        {
            var lastmess = chat.GetLastMessage();// смотрим на последнее сообщение и совершаем действие в зависимости от его содержания
            if (parser.IsMessageCommand(lastmess)) // отправляем на проверку на "текстовость" команды
            {
                await ExecCommand(chat, lastmess); // если ДА , то запускаем метод 
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
        public async Task ExecCommand(Conversation chat,string command)
        {
            if (parser.IsTextCommand(command)) // текстовая колманда
            {
                var text = parser.GetMessageText(chat, command);

                await SendText(chat, text);
            }
            if (parser.IsButtonCommand(command)) // клавишная команда 
            {
                var keys = parser.GetKeyBoard(command);
                var text = parser.GetInformationalMeggase(command);
                parser.AddCallback(command, chat);

                await SendTextWithKeyBoard(chat, text, keys);
            }
        }
        private string CreateTextMessage()
        {
            var text = "Not a command";

            return text;
        }
        private async Task SendTextWithKeyBoard(Conversation chat, string text, InlineKeyboardMarkup keyboard)
        {
            await botClient.SendTextMessageAsync(
                  chatId: chat.GetId(),
                  text: text,
                  replyMarkup: keyboard
                );
        }
    }
}
