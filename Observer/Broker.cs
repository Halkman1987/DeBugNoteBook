using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    class Broker:IObserver
    {
        IObservable stok;

        public Broker(IObservable obs)
        {
            stok = obs;
            stok.RegisterObserver(this);
        }
        public void Update(object o)
        {
            StockData sData = (StockData)o;
            if(sData.USD>85)
                Console.WriteLine($"Брокер продает доллары  по курсу {sData.USD}");
            else
                Console.WriteLine($"Брокер покупает доллары  по курсу {sData.USD}");

        }
        public void StopTrade()
        {
            stok.RemoveObserver(this);
            stok = null;
        }
    }
}
