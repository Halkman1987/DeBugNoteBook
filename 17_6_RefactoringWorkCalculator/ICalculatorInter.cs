using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17_6_RefactoringWorkCalculator
{
    public interface ICalculatorInter
    {
        public string Type { get; set; }

        // баланс учетной записи
        public double Balance { get; set; }

        // процентная ставка
        public double Interest { get; set; }
        public void GetTypeAccount()
        {

        }

    }
}
