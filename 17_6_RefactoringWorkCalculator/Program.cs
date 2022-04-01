using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17_6_RefactoringWorkCalculator
{
    class Program
    {
        static void Main()
        {
            ICalculatorInter c = new CashAccount();
            c.Balance = 40000;
            c.Type = "Зарплатный";
            Calculator.NewCalculateInterest(c);


            ICalculatorInter accc = new SimpeAccount();
            accc.Balance = 90000;
            accc.Type = "Обычный";
            Calculator.NewCalculateInterest(accc);



        }
    }
}