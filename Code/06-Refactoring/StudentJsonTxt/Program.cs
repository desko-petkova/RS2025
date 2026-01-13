// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace StudentJsonTxt
{
    using StudentJsonTxt.Models;
    using StudentJsonTxt.Repositories;

    /// <summary>
    /// Входна точка на приложението.
    /// Демонстрира запис и зареждане на ученици в различни формати.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Стартира конзолното меню.
        /// </summary>
        static void Main(string[] args)
        {
            List<Student> students = new();
            IStudentRepository repoTxt = new StudentRepositoryTxt();
            IStudentRepository repoJson = new StudentRepositoryJson();
            IStudentRepository repoXml = new StudentRepositoryXml();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Student TXT vs JSON ===");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Show All");
                Console.WriteLine("3. Save TXT");
                Console.WriteLine("4. Load TXT");
                Console.WriteLine("5. Save JSON");
                Console.WriteLine("6. Load JSON");
                Console.WriteLine("7. Save Xml");
                Console.WriteLine("8. Load Xml");
                Console.WriteLine("x. Exit");

                Console.WriteLine("Choose: ");

                string choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            AddStudent(students);
                            Console.WriteLine("Student added!");
                            Console.ReadLine();
                            break;
                        case "2":
                            ShowStudents(students);
                            Console.ReadLine();
                            break;
                        case "3":
                            repoTxt.Save(students);
                            Console.WriteLine("== Save in TXT ==");
                            Console.ReadLine();
                            break;
                        case "4":
                            students = repoTxt.Load();
                            Console.WriteLine("== Load from TXT ==");
                            Console.ReadLine();
                            break;
                        case "5":
                            repoJson.Save(students);
                            Console.WriteLine("== Save in Json ==");
                            Console.ReadLine();
                            break;
                        case "6":
                            students = repoJson.Load();
                            Console.WriteLine("== Load from Json ==");
                            Console.ReadLine();
                            break;
                        case "7":
                            repoXml.Save(students);
                            Console.WriteLine("== Save in Xml ==");
                            Console.ReadLine();
                            break;
                        case "8":
                            students = repoXml.Load();
                            Console.WriteLine("== Load from Xml ==");
                            Console.ReadLine();
                            break;
                        case "x":
                            return;
                        default:
                            Console.WriteLine("Invalid choice!");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        private static void ShowStudents(List<Student> students)
        {
            Console.Clear();
            Console.WriteLine("== List of all Students ==");
            if (students.Count == 0)
            {
                Console.WriteLine("No Students!");
                return;
            }

            foreach (Student s in students)
            {
                Console.WriteLine(s);
            }
        }

        private static void AddStudent(List<Student> students)
        {
            Console.WriteLine("=== Add Student ===");

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Grade: ");
            int grade = int.Parse(Console.ReadLine());

            students.Add(new Student(name, grade));
        }
    }
}
