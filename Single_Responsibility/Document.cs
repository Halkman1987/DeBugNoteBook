using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Single_Responsibility
{
    class Document
    {
        public string Text { get; set; }

        public void ScrollUp()
        {
            Console.WriteLine($"Прокрутка вверх");
        }

        public void ScrollDown()
        {
            Console.WriteLine($"Прокрутка вниз");
        }

        public void ZoomIn()
        {
            Console.WriteLine("Увелчиваем масштаб");
        }

        public void Export(IExporter exporter)
        {
            
            exporter.Export(Text);
        }
    }
}
