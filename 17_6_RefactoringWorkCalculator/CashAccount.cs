using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17_6_RefactoringWorkCalculator
{
    public class CashAccount : ICalculatorInter
    {
        public string Type { get; set; }

        // баланс учетной записи
        public double Balance { get; set; }

        // процентная ставка
        public double Interest { get; set; }


        void GetTypeAccount()
        {
            this.Type = "Зарплатный";
            this.Interest = 5;
        }


    }
}
