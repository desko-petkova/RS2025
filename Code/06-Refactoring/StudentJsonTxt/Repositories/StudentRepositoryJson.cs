// ------------------------------------------------------------
// <copyright file="StudentRepositoryJson.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// ------------------------------------------------------------
namespace StudentJsonTxt.Repositories
{
    using System.Collections.Generic;
    using System.Text.Json;
    using StudentJsonTxt.Models;

    /// <summary>
    /// Реализация на IStudentRepository за работа с JSON файлове.
    /// </summary>
    public class StudentRepositoryJson : IStudentRepository
    {
        private readonly string _filePath;

        /// <summary>
        /// Initializes a new instance of the <see cref="StudentRepositoryJson"/> class.
        /// Създава JSON репозитори с подаден път до файл.
        /// </summary>
        /// <param name="filePath">Име на JSON файла</param>
        public StudentRepositoryJson(string filePath = "students.json")
        {
            this._filePath = filePath;
        }

        /// <summary>
        /// Записва учениците в JSON файл.
        /// </summary>
        public void Save(List<Student> students)
        {
            var json = JsonSerializer.Serialize(students);
            File.WriteAllText(_filePath, json);
        }

        /// <summary>
        /// Зарежда учениците от JSON файл.
        /// </summary>
        /// <returns>Списък с ученици</returns>
        public List<Student> Load()
        {
            var list = new List<Student>();
            if (!File.Exists(_filePath))
            {
                return new List<Student>();
            }

            var json = File.ReadAllText(this._filePath);
            var students = JsonSerializer.Deserialize<List<Student>>(json);
            return students;
        }
    }
}
