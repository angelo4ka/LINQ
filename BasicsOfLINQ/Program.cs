using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicsOfLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Списки и переменные для работы программы
            string[] teams = { "Бавария", "Боруссия", "Реал Мадрид", "Манчестер Сити", "ПСЖ", "Барселона" };
            string character;
            int[] numbers = { 1, 2, 3, 4, 10, 34, 55, 66, 77, 88 };
            List<User> users = new List<User>
            {
                new User {Name="Том", Age=23, Languages = new List<string> {"английский", "немецкий" }}, // Добавление в список нового объекта (пользователя)
                new User {Name="Боб", Age=27, Languages = new List<string> {"английский", "французский" }},
                new User {Name="Джон", Age=29, Languages = new List<string> {"английский", "испанский" }},
                new User {Name="Элис", Age=24, Languages = new List<string> {"испанский", "немецкий" }}
            };
            List<User> users1 = new List<User>();
            users1.Add(new User { Name = "Sam", Age = 43 });
            users1.Add(new User { Name = "Tom", Age = 33 });
            #endregion


            //#region Урок 1
            //Console.Write("Введите букву команды, по которой будет происходить выборка (регистр не имеет значения): ");
            //character = Console.ReadLine();
            //character = character.ToUpper();

            //Scoring(teams, character);
            //SelectionWithLINQ(teams, character);
            //#endregion

            //ComplexFiltersLINQ(users);
            ProjectionLINQ1(users1);

            Console.WriteLine("Конец программы. Для выхода из неё нажмите любую клавишу на клавиатуре.");
            Console.ReadKey();
        }

        /// <summary>
        /// Обычная (стандартная) выборка из массива строки, начинающиеся на определенную букву и сортировка полученного списка
        /// </summary>
        /// <param name="teams">Массив строк для выборки</param>
        public static void StandardSelection(string[] teams, string character)
        {
            var selectedTeams = new List<string>();
            foreach (string s in teams)
            {
                if (s.ToUpper().StartsWith(character))
                    selectedTeams.Add(s);
            }
            selectedTeams.Sort();

            foreach (string s in selectedTeams)
                Console.WriteLine(s);
            Console.WriteLine();
        }

        /// <summary>
        /// Выборка с помощью LINQ из массива строки, начинающиеся на определенную букву и сортировка полученного списка
        /// </summary>
        /// <param name="teams">Массив строк для выборки</param>
        public static void SelectionWithLINQ(string[] teams, string character)
        {
            var selectedTeams = from t in teams // Определяем каждый объект из teams как t
                                where t.ToUpper().StartsWith(character) // Фильтрация по критерию
                                orderby t  // Упорядочиваем по возрастанию
                                select t; // Выбираем объект

            foreach (string s in selectedTeams)
                Console.WriteLine(s);
            Console.WriteLine();
        }

        /// <summary>
        /// Выборка с помощью методов расширения LINQ из массива строки, начинающиеся на определенную букву и сортировка полученного списка
        /// </summary>
        /// <param name="teams">Массив строк для выборки</param>
        public static void SelectionWithLINQExtensionMethods(string[] teams, string character)
        {
            var selectedTeams = teams.Where(t => t.ToUpper().StartsWith("Б")).OrderBy(t => t);

            foreach (string s in selectedTeams)
                Console.WriteLine(s);
            Console.WriteLine();
        }

        /// <summary>
        /// Подсчёт количества результатов выборки
        /// </summary>
        /// <param name="teams">Массив строк для выборки</param>
        public static void Scoring(string[] teams, string character)
        {
            int number = (from t in teams
                          where t.ToUpper().StartsWith(character)
                          select t).Count();
            
            if (number != 0)
                Console.WriteLine($"Найдено: {number}\n=====================");
            else Console.WriteLine("Результат: по Вашему запросу ничего не найдено.");
        }

        /// <summary>
        /// Фильтрация с помощью операторов LINQ: выбор всех чётных элементов, которые больше 10
        /// </summary>
        /// /// <param name="numbers">Одномерный массив, хранящий данные типа int (набор чисел)</param>
        public static void FilteringLINQ(int[] numbers)
        {
            // Перечислитель параметров типа int
            IEnumerable<int> evens = from i in numbers // Определяем каждый объект из numbers как i
                                     where i % 2 == 0 && i > 10 // Фильтрация по критерию (находим чётные элементы, которые больше 10)
                                     select i; // Выбираем объект (добавляем в перечислитель)

            // Каждый элемент из перечислителя "evens" выводится (печатается) на экран
            foreach (int i in evens) 
                Console.WriteLine(i);
            Console.WriteLine();
        }

        /// <summary>
        /// Фильтрация с помощью метода расширения: выбор всех чётных элементов, которые больше 10
        /// </summary>
        /// <param name="numbers">Одномерный массив, хранящий данные типа int (набор чисел)</param>
        public static void FilteringEM(int[] numbers)
        {
            // В перечислитель параметров типа int выбираем и добавляем чётные элементы, которые больше 10
            IEnumerable<int> evens = numbers.Where(i => i % 2 == 0 && i > 10);

            // Каждый элемент из перечислителя "evens" выводится (печатается) на экран
            foreach (int i in evens)
                Console.WriteLine(i);
            Console.WriteLine();
        }

        /// <summary>
        /// Выборка сложных объектов с помощью операторов LINQ: выбор из пользователей, возраст которых больше 25 лет
        /// </summary>
        /// <param name="users">Список пользователей, включающий в себя объекты класса User (пользователь)</param>
        public static void SelectingComplexObjLINQ(List<User> users)
        {
            var selectedUsers = from user in users
                                where user.Age > 25 // Выборка пользователей, возраст которых больше 25 лет
                                select user;

            // Вывод информации о пользователях из выборки
            foreach (User user in selectedUsers)
                Console.WriteLine($"{user.Name} - {user.Age}");
            Console.WriteLine();
        }

        /// <summary>
        /// Выборка сложных объектов с помощью метода расширения: выбор из пользователей, возраст которых больше 25 лет
        /// </summary>
        /// <param name="users">Список пользователей, включающий в себя объекты класса User (пользователь)</param>
        public static void SelectingComplexObjEM(List<User> users)
        {
            var selectedUsers = users.Where(u => u.Age > 25); // Выборка пользователей, возраст которых больше 25 лет

            // Вывод информации о пользователях из выборки
            foreach (User user in selectedUsers)
                Console.WriteLine($"{user.Name} - {user.Age}");
            Console.WriteLine();
        }

        /// <summary>
        /// Сложные фильтры с помощью операторов LINQ: фильтрование пользователей по языку (английский)
        /// </summary>
        /// <param name="users">Список пользователей, включающий в себя объекты класса User (пользователь)</param>
        public static void ComplexFiltersLINQ(List<User> users)
        {
            var selectedUsers = from user in users // Определяем каждый объект из users как user
                                from lang in user.Languages // Определяем каждый объект из списка Languages у каждого пользователя как lang
                                where user.Age < 28 // Находим пользователей, возраст которых меньше 28 лет
                                where lang == "английский" // Находим пользователей с английским языком
                                select user; // Выбираем объект

            foreach (User user in selectedUsers)
                Console.WriteLine($"{user.Name} - {user.Age}");
            Console.WriteLine();
        }

        /// <summary>
        /// Сложные фильтры с помощью методов расширения: фильтрование пользователей по языку (английский)
        /// </summary>
        /// <param name="users">Список пользователей, включающий в себя объекты класса User (пользователь)</param>
        public static void ComplexFiltersEM(List<User> users)
        {
            var selectedUsers = users.SelectMany(u => u.Languages, // Последовательность, которую надо проецировать
                            // Функция преобразования, которая применяется к каждому элементу
                            (u, l) => new { User = u, Lang = l })
                          .Where(u => u.Lang == "английский" && u.User.Age < 28)
                          .Select(u => u.User);

            foreach (User user in selectedUsers)
                Console.WriteLine($"{user.Name} - {user.Age}");
            Console.WriteLine();
        }

        /// <summary>
        /// Проекция с помощью операторов LINQ: выбор св-ва Name
        /// </summary>
        public static void ProjectionLINQ1(List<User> users)
        {
            var names = from u in users // Определяем каждый объект из users как u
                        select u.Name; // Выбираем объект - имя пользователя

            foreach (string n in names)
                Console.WriteLine(n);
            Console.WriteLine();
        }

        /// <summary>
        /// Проекция с помощью операторов LINQ: выбор объекта анонимного типа
        /// </summary>
        public static void ProjectionLINQ2(List<User> users)
        {
            var names = from u in users 
                        select u.Name; // Выбираем объект - имя пользователя

            foreach (string n in names)
                Console.WriteLine(n);
            Console.WriteLine();
           
            var items = from u in users // Определяем каждый объект из users как u
                        select new // Выбираем объект анонимного типа
                        {
                            FirstName = u.Name,
                            DateOfBirth = DateTime.Now.Year - u.Age // Высчитываем год рождения
                        };

            foreach (var n in items)
                Console.WriteLine($"{n.FirstName} - {n.DateOfBirth}");
            Console.WriteLine();
        }

        /// <summary>
        /// Проекция с помощью метода расширения Select: выбор объекта анонимного типа
        /// </summary>
        public static void ProjectionEM(List<User> users)
        {
            var names = users.Select(u => u.Name); // Выборка имён

            // Выборка объектов анонимного типа
            var items = users.Select(u => new
            {
                FirstName = u.Name,
                DateOfBirth = DateTime.Now.Year - u.Age
            });

            foreach (var n in items)
                Console.WriteLine($"{n.FirstName} - {n.DateOfBirth}");
            Console.WriteLine();
        }
    }
}
