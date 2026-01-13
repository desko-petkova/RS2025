// <copyright file="StudentRepositoryXml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace StudentJsonTxt.Repositories
{
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using StudentJsonTxt.Models;

    /// <summary>
    /// Реализация на IStudentRepository за работа с XML файлове.
    /// </summary>
    public class StudentRepositoryXml : IStudentRepository
    {
        private readonly string _filePath;

        /// <summary>
        /// Initializes a new instance of the <see cref="StudentRepositoryXml"/> class.
        /// Създава XML репозитори с подаден път до файл.
        /// </summary>
        public StudentRepositoryXml(string filePath = "students.xml")
        {
            this._filePath = filePath;
        }

        /// <summary>
        /// Записва учениците в XML файл.
        /// </summary>
        public void Save(List<Student> students)
        {
            var allData = new XmlSerializer(typeof(List<Student>));

            using (var steam = new FileStream(this._filePath, FileMode.Create))
            {
                allData.Serialize(steam, students);
            }
        }

        /// <summary>
        /// Зарежда учениците от XML файл.
        /// </summary>
        /// <returns>Списък с ученици.</returns>
        public List<Student> Load()
        {
            var list = new List<Student>();
            if (!File.Exists(this._filePath))
            {
                return new List<Student>();
            }

            var allData = new XmlSerializer(typeof(List<Student>));

            using (var stream = new FileStream(this._filePath, FileMode.Open))
            {
                var students = allData.Deserialize(stream) as List<Student>;
                return students;
            }
        }
    }
}
