using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeBugWorkOnlyNoutbook
{
    public class CommandParser // Хранилище комманд
    {
        
        public void AddCommands(IChatCommand chatCommand)
        {
            Command.Add(chatCommand);
        }
        private List<IChatCommand> Command;//список команд
        public CommandParser()
        {
            Command = new List<IChatCommand>(); // добавление команды в лист
        }
        public bool IsTextCommand(string message) //метод проверки на текстовая ли команда
        {
            var command = Command.Find(x => x.CheckMessage(message)); //команду из Листа 

            return command is IChatTextCommand;
        }
        public bool IsMessageCommand(string mess)
        {
            var b = false;
            return b;
        }
      /*  public List<string> GetTextMessages() /// Возврат всех сообщений 
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
        }*/
        /*public string GetMessageText(Conversation chat, string command)
        {
            var text =
            return text;
        }*/
        public string GetMessageText(Conversation chat,string message)
        {
            var command = Command.Find(x => x.CheckMessage(message)) as IChatTextCommand;

            if (command is IChatTextCommand)
            {
               /* if (!(command as IChatTextCommand).DoAction(chat))
                {
                    return "Ошибка выполнения команды!";
                };*/
            }

            return command.ReturnText();
        }
    }
}
