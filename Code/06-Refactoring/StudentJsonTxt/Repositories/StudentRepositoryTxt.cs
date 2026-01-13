// <copyright file="StudentRepositoryTxt.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace StudentJsonTxt.Repositories
{
    using System.Collections.Generic;
    using StudentJsonTxt.Models;

    /// <summary>
    /// Реализация на IStudentRepository за работа с TXT файлове.
    /// </summary>
    public class StudentRepositoryTxt : IStudentRepository
    {

        private readonly string _filePath;

        /// <summary>
        /// Initializes a new instance of the <see cref="StudentRepositoryTxt"/> class.
        /// Създава TXT репозитори с подаден път до файл.
        /// </summary>
        public StudentRepositoryTxt(string filePath = "students.txt")
        {
            this._filePath = filePath;
        }

        /// <summary>
        /// Записва учениците в текстов файл.
        /// Всеки ученик е на нов ред във формат: Name;Grade
        /// </summary>
        public void Save(List<Student> students)
        {
            var lines = new List<string>();
            foreach (var s in students)
            {
                lines.Add($"{s.Name};{s.Grade}");
            }

            File.WriteAllLines(this._filePath, lines); // Презаписва целия файл
        }

        /// <summary>
        /// Зарежда учениците от текстов файл.
        /// </summary>
        /// <returns>Списък с ученици</returns>
        public List<Student> Load()
        {
            var list = new List<Student>();

            if (!File.Exists(this._filePath))
            {
                return list;
            }

            var lines = File.ReadAllLines(this._filePath);
            foreach (var line in lines)
            {
                var parts = line.Split(';');
                string name = parts[0];
                int grade = int.Parse(parts[1]);

                list.Add(new Student(name, grade));
            }
            return list;
        }
    }
}
