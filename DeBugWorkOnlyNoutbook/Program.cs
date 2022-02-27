using System;
using System.Collections;
using System.Diagnostics;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Collections.Generic;
using System.Linq;

namespace DeBugWorkOnlyNoutbook
{


    class Programm
    {
        public class Car
        {
            public string Manufacturer { get; set; }
            public string CountryCode { get; set; }

            public Car(string manufacturer, string countryCode)
            {
                Manufacturer = manufacturer;
                CountryCode = countryCode;
            }
        }
        class Contact
        {
            public Contact(string name, string lastName, long phoneNumber, String email) // метод-конструктор
            {
                Name = name;
                LastName = lastName;
                PhoneNumber = phoneNumber;
                Email = email;
            }

            public string Name { get; }
            public string LastName { get; }
            public long PhoneNumber { get; }
            public string Email { get; }
        }
        class Coarse
        {
            public string Name { get; set; }
            public DateTime StartDate { get; set; }
        }
        public class Student
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public List<string> Languages { get; set; }
        }
        public class Application
        {
            public string Name { get; set; }
            public int YearOfBirth { get; set; }
        }
        public class City
        {
            public City(string name, long population)
            {
                Name = name;
                Population = population;
            }

            public string Name { get; set; }
            public long Population { get; set; }
        }
        static void Main()
        {
            var phoneBook = new List<Contact>();

            // добавляем контакты
            phoneBook.Add(new Contact("Игорь", "Николаев", 79990000001, "igor@example.com"));
            phoneBook.Add(new Contact("Сергей", "Довлатов", 79990000010, "serge@example.com"));
            phoneBook.Add(new Contact("Анатолий", "Карпов", 79990000011, "anatoly@example.com"));
            phoneBook.Add(new Contact("Валерий", "Леонтьев", 79990000012, "valera@example.com"));
            phoneBook.Add(new Contact("Сергей", "Брин", 799900000013, "serg@example.com"));
            phoneBook.Add(new Contact("Иннокентий", "Смоктуновский", 799900000013, "innokentii@example.com"));
            while (true)
            {
                var KeyChar = Console.ReadKey().KeyChar;
                var parsed = Int32.TryParse(KeyChar.ToString(), out int pageNumber);
                //Console.Clear();
                if (!parsed || pageNumber<1 || pageNumber>3)
                {
                    Console.WriteLine(" Fignya");
                }
                else
                {
                    var pageCon = phoneBook.Skip((pageNumber - 1) * 2).Take(2);
                    Console.WriteLine();
                    foreach (var entry in pageCon)
                        Console.WriteLine(entry.Name + " " + entry.LastName + ": " + entry.PhoneNumber);
                }
            }

            var contacts = new List<Contact>()
            {
               new Contact() { Name = "Андрей", Phone = 7999945005 },
               new Contact() { Name = "Сергей", Phone = 799990455 },
               new Contact() { Name = "Иван", Phone = 79999675 },
               new Contact() { Name = "Игорь", Phone = 8884994 },
               new Contact() { Name = "Анна", Phone = 665565656 },
               new Contact() { Name = "Василий", Phone = 3434 }
            };
           
            while (true)
            {
                var KeyChar = Console.ReadKey().KeyChar;
                Console.Clear();
                if (!Char.IsDigit(KeyChar))
                {
                    Console.WriteLine(" Fignya");
                }
                else
                {
                    IEnumerable<Contact> page = null;


                    switch (KeyChar)
                    {
                        case ('1'):
                            page = contacts.Take(2);
                            break;

                        case ('2'):
                            page = contacts.Skip(2).Take(2);
                            break;
                        case ('3'):
                            page = contacts.Skip(4).Take(2);
                            break;
                    }
                    if(page == null)
                    {
                        Console.WriteLine($"Ошибка ввода, страницы {KeyChar} не существует");
                        continue;
                    }
                    foreach (var c in page)
                        Console.WriteLine(c.Name + " " + c.Phone);
                }
            }

            
            //-------------------------------------------------------------
            List<Student> students = new List<Student>
            {
                new Student {Name="Андрей", Age=23, Languages = new List<string> {"английский", "немецкий" }},
                new Student {Name="Сергей", Age=27, Languages = new List<string> {"английский", "французский" }},
                new Student {Name="Дмитрий", Age=29, Languages = new List<string> {"английский", "испанский" }},
                new Student {Name="Василий", Age=24, Languages = new List<string> {"испанский", "немецкий" }}
            };
            var coarses = new List<Coarse>
            {
              new Coarse {Name="Язык программирования C#", StartDate = new DateTime(2020, 12, 20)},
              new Coarse {Name="Язык SQL и реляционные базы данных", StartDate = new DateTime(2020, 12, 15)},
            };

            var StudList = from s in students
                           where s.Languages.Contains("английский")
                           where s.Age < 29
                           let bitrh = DateTime.Now.Year - s.Age
                           from c in coarses
                           where c.Name.Contains("C#")
                           select new
                           {
                               Name = s.Name,
                               YearOfBirth = bitrh,
                               NameCourse = c.Name
                           };
            foreach (var i in StudList)
                Console.WriteLine(i.Name + " " + i.YearOfBirth + " " + i.NameCourse);

            //-----------------------------------------------------
            string[] words = { "Обезьяна", "Лягушка", "Кот", "Собака", "Черепаха" };
            var anim = words.Select(a =>
           new
           {
               Name = a,
               Length = a.Length
           })
                .OrderBy(L => L.Length);
            foreach (var a in anim)
                Console.WriteLine($"{a.Name} - {a.Length} букв");


            //----------------------------------------------------------
            var numsList = new List<int[]>()
            {
               new[] {2, 3, 7, 1},
               new[] {45, 17, 88, 0},
               new[] {23, 32, 44, -6},
            };
            var newL = numsList.SelectMany(
                s => s).OrderBy(s => s);
            foreach (var n in newL)
                Console.WriteLine(n);


            //--------------------------------------------------------------
            string[] text =
            { "Раз два три",
              "четыре пять шесть",
              "семь восемь девять"
            };
            var word = from str in text
                       from s in str.Split(' ')
                       select s;

            //--------------------------------------------------------------------------------------
            var Countries = new Dictionary<string, List<City>>();
            // Добавим Россию с её городами
            var russianCities = new List<City>();
            russianCities.Add(new City("Москва", 11900000));
            russianCities.Add(new City("Санкт-Петербург", 4991000));
            russianCities.Add(new City("Волгоград", 1099000));
            russianCities.Add(new City("Казань", 1169000));
            russianCities.Add(new City("Севастополь", 449138));
            Countries.Add("Россия", russianCities);

            // Добавим Беларусь
            var belarusCities = new List<City>();
            belarusCities.Add(new City("Минск", 1200000));
            belarusCities.Add(new City("Витебск", 362466));
            belarusCities.Add(new City("Гродно", 368710));
            Countries.Add("Беларусь", belarusCities);

            // Добавим США
            var americanCities = new List<City>();
            americanCities.Add(new City("Нью-Йорк", 8399000));
            americanCities.Add(new City("Вашингтон", 705749));
            americanCities.Add(new City("Альбукерке", 560218));
            Countries.Add("США", americanCities);

            var town = from country in Countries
                       from city in country.Value
                       where city.Population > 1000000
                       orderby city.Population descending
                       select city;
            foreach (var city in town)
                Console.WriteLine(city.Name + " - " + city.Population);
            //-------------------------------------------------------------------------------------


            var objects = new List<object>()
            {
                1,
               "Сергей ",
               "Андрей ",
                300,
            };
            var selectH = from p in objects
                          where p is string
                          orderby p
                          select p;

            foreach (var select in objects.Where(p => p is string).OrderBy(p => p))
                Console.WriteLine(select);

            var BigSity = from city in russianCities
                          where city.Population > 1000000
                          orderby city.Population descending
                          select city;
            var Citys = russianCities.Where(c => c.Name.Length <= 10).
                        OrderBy(c => c.Name.Length);


        }

    }
}

