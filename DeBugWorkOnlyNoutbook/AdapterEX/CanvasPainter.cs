using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeBugWorkOnlyNoutbook
{
    internal class CanvasPainter : IPainter
    {
        public void Pain()
        {
            Console.WriteLine("Рисуем на холсте");
        }
    }
}
