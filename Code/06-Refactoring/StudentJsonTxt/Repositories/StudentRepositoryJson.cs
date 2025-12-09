using StudentJsonTxt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace StudentJsonTxt.Repositories
{
    public class StudentRepositoryJson : IStudentRepository
    {
        private readonly string _filePath;
        public StudentRepositoryJson(string filePath = "students.json")
        {
            _filePath = filePath;
        }
        public void Save(List<Student> students)
        {
            var json = JsonSerializer.Serialize(students);
            File.WriteAllText(_filePath, json);
        }
        public List<Student> Load()
        {
            var list = new List<Student>();
            if (!File.Exists(_filePath))
                return list;
            var json = File.ReadAllText(_filePath);
            var students = JsonSerializer.Deserialize<List<Student>>(json);
            return students;

        }
    }
}
