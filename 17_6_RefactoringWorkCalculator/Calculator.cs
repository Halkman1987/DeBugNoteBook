using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17_6_RefactoringWorkCalculator
{
    public static class Calculator
    {
        // Метод для расчета процентной ставки
        // поменять метод добавления нового типа аккаунта
        /* public static void CalculateInterest(Account account)
         {
             if (account.Type == "Обычный")
             {
                 // расчет процентной ставки обычного аккаунта по правилам банка
                 account.Interest = account.Balance * 0.4;

                 if (account.Balance < 1000)
                     account.Interest -= account.Balance * 0.2;

                 if (account.Balance < 50000)
                     account.Interest -= account.Balance * 0.4;
             }
             else if (account.Type == "Зарплатный")
             {
                 // расчет процентной ставк зарплатного аккаунта по правилам банка
                 account.Interest = account.Balance * 0.5;
             }
         }*/
        public static void NewCalculateInterest(ICalculatorInter account)
        {
            if (account.Type == "Обычный")
            {
                // расчет процентной ставки обычного аккаунта по правилам банка
                account.Interest = account.Balance * 0.4;
               

                if (account.Balance < 1000)
                    account.Interest -= account.Balance * 0.2;
                

                if (account.Balance < 50000)
                    account.Interest -= account.Balance * 0.4;
               
            }
            else if (account.Type == "Зарплатный")
            {
                // расчет процентной ставк зарплатного аккаунта по правилам банка
                account.Interest = account.Balance * 0.5;
               
            }
            Console.WriteLine($"Ваш Тип :{account.Type}\nВаша ставка : {account.Interest}");
        }


        public static void CalculateInterest(Account account)
        {
            if (account.Type == "Обычный")
            {
                // расчет процентной ставки обычного аккаунта по правилам банка
                account.Interest = account.Balance * 0.4;


                if (account.Balance < 1000)
                    account.Interest -= account.Balance * 0.2;


                if (account.Balance < 50000)
                    account.Interest -= account.Balance * 0.4;

            }
            else if (account.Type == "Зарплатный")
            {
                // расчет процентной ставк зарплатного аккаунта по правилам банка
                account.Interest = account.Balance * 0.5;

            }
            Console.WriteLine($"Ваш Тип :{account.Type}\nВаша ставка : {account.Interest}");
        }
    }
}
