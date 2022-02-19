using System;
using System.Diagnostics;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace DeBugWorkOnlyNoutbook
{


    class Programm
    {
        class User
        {
            public string Login { get; set; }
            public string Name { get; set; }
            public bool IsPremium { get; set; }
        }
        static void ShowAds()
        {
            Console.WriteLine("Посетите наш новый сайт с бесплатными играми free.games.for.a.fool.com");
            // Остановка на 1 с
            Thread.Sleep(1000);

            Console.WriteLine("Купите подписку на МыКомбо и слушайте музыку везде и всегда.");
            // Остановка на 2 с
            Thread.Sleep(2000);

            Console.WriteLine("Оформите премиум-подписку на наш сервис, чтобы не видеть рекламу.");
            // Остановка на 3 с
            Thread.Sleep(3000);
        }
        static void Main()
        {
            UseString(70000);
            Console.WriteLine("Ready to switch");
            Console.ReadKey();

            UseStringBuilder(70000);
            Console.WriteLine("Ready to end");
            Console.ReadKey();




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

