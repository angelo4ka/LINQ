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
            string[] teams = { "Бавария", "Боруссия", "Реал Мадрид", "Манчестер Сити", "ПСЖ", "Барселона" };
            
            Scoring(teams);
            SelectionWithLINQ(teams);

            Console.Write("Конец программы. Для выхода из неё нажмите любую клавишу на клавиатуре.");
            Console.ReadKey();
        }

        /// <summary>
        /// Обычная (стандартная) выборка из массива строки, начинающиеся на определенную букву и сортировка полученного списка
        /// </summary>
        /// <param name="teams">Массив строк для выборки</param>
        public static void StandardSelection(string[] teams)
        {
            var selectedTeams = new List<string>();
            foreach (string s in teams)
            {
                if (s.ToUpper().StartsWith("Б"))
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
        public static void SelectionWithLINQ(string[] teams)
        {
            var selectedTeams = from t in teams // Определяем каждый объект из teams как t
                                where t.ToUpper().StartsWith("Б") // Фильтрация по критерию
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
        public static void SelectionWithLINQExtensionMethods(string[] teams)
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
        public static void Scoring(string[] teams)
        {
            int number = (from t in teams
                          where t.ToUpper().StartsWith("Б")
                          select t).Count();
            Console.WriteLine($"Найдено: {number}\n=====================");
        }
    }
}
