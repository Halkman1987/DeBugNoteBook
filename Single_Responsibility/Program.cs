using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Single_Responsibility
{
    class Program
    {
        static void Main()
        {
            IExporter exporter = new PdfExporter();
            Document document = new Document();
            document.Text = "Ну вот както так";
            document.Export(exporter);
        }
    }

}
