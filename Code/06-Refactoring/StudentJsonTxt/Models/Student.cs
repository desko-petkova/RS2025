// ------------------------------------------------------------
// <copyright file="Student.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// ------------------------------------------------------------
namespace StudentJsonTxt.Models
{
    /// <summary>
    /// Представя ученик с име и оценка.
    /// </summary>
    public class Student
    {
        private string name;
        private int grade;

        /// <summary>
        /// Gets or sets име на ученик.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets оценка на ученк.
        /// </summary>
        public int Grade { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Student"/> class.
        /// Конструктор нужен за сериализация (Json/XML).
        /// </summary>
        public Student()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Student"/> class.
        /// Конструктор създава ученик с име и оценка.
        /// </summary>
        /// <param name="name">Име на ученик.</param>
        /// <param name="grade">Оценка на ученик.</param>
        public Student(string name, int grade)
        {
            this.Name = name;
            this.Grade = grade;
        }

        /// <summary>
        /// Връща информация за ученика.
        /// </summary>
        /// <returns>Низ с име и оценка на ученик.</returns>
        public override string ToString()
        {
            return $"{this.Name} - {this.Grade}";
        }
    }
}
