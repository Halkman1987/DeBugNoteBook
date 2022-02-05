using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeBugWorkOnlyNoutbook
{
    internal class CommandParser // Хранилище комманд
    {
        private List<IChatCommand> Command;
        public CommandParser()
        {
            Command = new List<IChatCommand>();
        }
    }
}
