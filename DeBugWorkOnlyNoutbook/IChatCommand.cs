﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeBugWorkOnlyNoutbook
{
    public interface IChatCommand
    {
        bool CheckMessage(string message);
    }
}
