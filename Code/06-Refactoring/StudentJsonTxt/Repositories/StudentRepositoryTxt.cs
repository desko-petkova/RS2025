using StudentJsonTxt.Models;
using System.Collections.Generic;

namespace StudentJsonTxt.Repositories
{
    public class StudentRepositoryTxt : IStudentRepository
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
           // File.AppendAllLines(_filePath, lines);  // Дописва редове към файл
           File.WriteAllLines(_filePath, lines); // Презаписва целия файл
        }

        public List<Student> Load()
        {
            var list = new List<Student>();

            if (!File.Exists(_filePath))
                return list;

            var lines = File.ReadAllLines(_filePath);
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
