using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Single_Responsibility
{
    class PdfExporter : IExporter
    {
        public void Export(string text)
        {
            Console.WriteLine($"{text} => Экспортированно в ПДФ");
        }
    }
}
