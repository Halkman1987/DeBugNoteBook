using System;
using System.Collections;
using System.Diagnostics;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Collections.Generic;
using System.Linq;
using AdapterRealExample.Devices;

namespace DeBugWorkOnlyNoutbook
{


    class Programm
    {
       
        static void Main()
        {
            var imageDrawer = new ImageDrawer();

            PaperPrinter paperPrinter = new PaperPrinter();

            imageDrawer.DrawWith(paperPrinter);
            
            CanvasPainter canvasPainter = new CanvasPainter();

            IPrinter imagePrinter = new CanvasPainterToPrinterAdapter(canvasPainter);
           
        }

    }
}

