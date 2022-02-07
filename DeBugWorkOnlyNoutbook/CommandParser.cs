using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeBugWorkOnlyNoutbook
{
    public class CommandParser // Хранилище комманд
    {
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
    }
}
