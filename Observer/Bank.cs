using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    class Bank:IObserver
    {
        IObservable stok;
        public Bank(IObservable obs)
        {
            stok = obs;
            stok.RegisterObserver(this);
        }
        public void Update(object o)
        {
            StockData sData = (StockData)o;
            if(sData.Euro>85)
                Console.WriteLine($"Банк продает евро по курсу {sData.Euro}");
            else
                Console.WriteLine($"Банк покупает евро по курсу {sData.Euro}");
        }
    }
}
