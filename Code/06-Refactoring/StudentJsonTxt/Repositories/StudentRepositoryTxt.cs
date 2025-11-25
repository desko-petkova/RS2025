using StudentJsonTxt.Models;
using System.Collections.Generic;

namespace StudentJsonTxt.Repositories
{
    public class StudentRepositoryTxt
    {
        private readonly string _filePath;
        public StudentRepositoryTxt(string filePath = "students.txt")
        {
            _filePath = filePath;
        }

        public void Save(List<Student> students)
        {
            var lines = new List<string>();
            foreach (var s in students)
            {
                lines.Add($"{s.Name};{s.Grade}");
            }
            File.AppendAllLines(_filePath, lines);  // Дописва редове към файл
           // File.WriteAllLines(_filePath, lines); // Презаписва целия файл
        }

        public List<Student> Load()
        {
            var list = new List<Student>();

            if (!File.Exists(_filePath))
                return list;

            //TODO  
            //1.Прочитане на всички редове от файл
            //2.Разделяне(Split) по ';'
            //  * Първи елемент - име
            //  * Втори елемент - оценка
            //3.Създаване на Student
            //4.Добавяне в List < Student >

            return list;
        }
    }
}
