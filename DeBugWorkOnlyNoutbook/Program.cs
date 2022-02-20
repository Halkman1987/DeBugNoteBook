using System;
using System.Collections;
using System.Diagnostics;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace DeBugWorkOnlyNoutbook
{


    class Programm
    {

        class User
      
        static void Main()
        {
            var arrayList = new ArrayList()
           {
               1,
               "Андрей ",
               "Сергей ",
               300,
           };
            int sumN = 0 ;
            StringBuilder text = new StringBuilder();
            foreach(var el in arrayList)
            {
                if(el is int)
                {
                    sumN += (int)el;
                }
                if (el is string s)
                {
                    text.Append(el);
                }
            }
            var res = new ArrayList() { sumN, text.ToString() };
            foreach (var n in res)
            {
                Console.WriteLine(n);
            }

            var months = new[]
            {
                "Jan", "Feb", "Mar", "Apr", "May" , "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"
            };

            var numbers = new[]
            {
                1, 2, 3, 5, 6, 7, 8, 9, 10, 11, 12
            };
            var combiarray = new ArrayList();
            foreach(var n in numbers)
            {
                combiarray.Add(months[n - 1]);
                combiarray.Add(n);
            }
            foreach (var com in combiarray)
                Console.Write($"{com}, " );
            Console.WriteLine("---------------------");

            var list = new ArrayList() { 2, "Lol" };
            list.Add(2.3);
            list.Add(44);
            list.AddRange(new string[] { "Helo", "Word" });
            foreach (var o in list)
                Console.WriteLine(o);
            Console.WriteLine("---------------------");
            list.Add("again");
            foreach (var o in list)
                Console.WriteLine(o);
            Console.WriteLine("---------------------");
            var slice = list.GetRange(4, 3);
            foreach (var o in slice)
                Console.WriteLine(o);
            Console.WriteLine("---------------------");
            Console.WriteLine("---------------------");
            var arlist = new ArrayList()
            {
                1,
                "Dima",
                300,
                4.5f
            };
            foreach (var i in arlist)
                Console.WriteLine(i);
            Console.WriteLine("---------------------");
            int FirstEl = (int)arlist[0];
            Console.WriteLine(FirstEl);
            string TwoEl = (string)arlist[1];
            Console.WriteLine(TwoEl);

            foreach (var i in arlist)
                Console.WriteLine(i);
            arlist[0] = "Kate";
            arlist[1] = 111;
            Console.WriteLine("---------------------");
            foreach (var i in arlist)
                Console.WriteLine(i);


            string text = File.ReadAllText("C:/Users/Дмитрий/Desktop/cdev_Text.txt");
            char[] delimiters = { ' ', '\r', '\n' };
            var word = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            //Console.WriteLine(word.Length);

            /* UseString(70000);
            Console.WriteLine("Ready to switch");
            Console.ReadKey();

            UseStringBuilder(70000);
            Console.WriteLine("Ready to end");
            Console.ReadKey();
*/



            //var summary = BenchmarkRunner.Run<Testing>();
            //Estimate(20);
            //Console.ReadKey();
            static void CreateMatrix(int n)
            {
                var matrix = new int[n][];

                for (int i = 0; i < n; i++)
                {
                    matrix[i] = new int[n];
                    //Console.WriteLine($"{matrix[i]}");
                }

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        matrix[i][j] = i + j;
                        //Console.WriteLine($"{matrix[j]}");
                    }
                }

            }

            static void Estimate(int n)
            {
                // var timer = new Stopwatch();
                //timer.Start();

                for (int i = 0; i < n; i++)
                {
                    //timer.Restart();

                    CreateMatrix(10000);

                    // timer.Stop();
                    //Console.WriteLine(timer.ElapsedMilliseconds);
                }
            }
            /*List<User> users = new List<User>();
            users.Add(new User() { Name = "Dima", IsPremium = false });
            users.Add(new User() { Name = "Petya", IsPremium = false });
            users.Add(new User() { Name = "Vasya", IsPremium = true });
            foreach (User user in users)
            {
                if (user.IsPremium == false)
                {
                    Console.WriteLine($"Hello {user.Name}");
                    ShowAds();
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine($"Hello {user.Name} you have is Premium account");
                    return;
                    Console.WriteLine();
                }
            }
            static int BinarySearch(int value, int[] array)
            {
                var left = array[0];
                var rigth = array.Length;
                while (left <= rigth)
                {
                    var middle = (rigth + left) / 2;
                    var midEl = array[middle];
                    if (midEl == value)
                    {
                        return middle;
                    }
                    else if (value < midEl)
                    {
                        rigth = middle - 1;
                    }
                    else
                    {
                        left = middle + 1;
                    }
                }
                return -1;
            }*/
        }
        static string UseString(int n)
        {
            string value = "";

            for (int i = 0; i < n; i++)
            {
                value += i.ToString();
                value += " ";
                Console.WriteLine($" add string {i}");
            }

            return value;
        }

        static string UseStringBuilder(int n)
        {
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                builder.Append(i.ToString());
                builder.Append(" ");
                Console.WriteLine($" add string {i}");
            }

            return builder.ToString();

        }
    }
}

