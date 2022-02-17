using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;

namespace DeBugWorkOnlyNoutbook
{
    public class CommandParser // Хранилище комманд
    {
        private List<IChatCommand> Command;//список команд
        public void AddCommands(IChatCommand chatCommand)
        {
            Command.Add(chatCommand);
        }
        
        public CommandParser()
        {
            Command = new List<IChatCommand>(); // добавление команды в лист
        }

        public bool IsMessageCommand(string message)
        {
            return Command.Exists(x => x.CheckMessage(message));
        }

        public bool IsTextCommand(string message) //метод проверки на текстовая ли команда
        {
            var command = Command.Find(x => x.CheckMessage(message)); //команду из Листа 

            return command is IChatTextCommand;
        }

        public bool IsButtonCommand(string message) //метод проверки на текстовая ли команда
        {
            var command = Command.Find(x => x.CheckMessage(message)); //команду из Листа 

            return command is IKeyBoardCommand;
        }

        
        public string GetMessageText(Conversation chat,string message)
        {
            var command = Command.Find(x => x.CheckMessage(message)) as IChatTextCommand;

            if (command is IChatTextCommand)
            {
               // if (command as IChatTextCommand)//DoAction(chat))
                {
                    return "Ошибка выполнения команды!";
                };
            }

            return command.ReturnText();
        }
        public string GetInformationalMeggase(string message)
        {
            var command = Command.Find(x => x.CheckMessage(message)) as IKeyBoardCommand;

            return command.InformationalMessage();
        }
        public void AddCallback(string message, Conversation chat)
        {
            var command = Command.Find(x => x.CheckMessage(message)) as IKeyBoardCommand;
            command.AddCallBack(chat);
        }
        public InlineKeyboardMarkup GetKeyBoard(string message)
        {
            var command = Command.Find(x => x.CheckMessage(message)) as IKeyBoardCommand;

            return command.ReturnKeyBoard();
        }
    }
}
