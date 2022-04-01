using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    class Program
    {

        static void Main(string[] args)
        {
            Stok stok = new Stok();
            var bank = new Bank(stok);
            var broker = new Broker(stok);
            stok.Market();
            broker.StopTrade();
            stok.Market();
        }
    }

}
