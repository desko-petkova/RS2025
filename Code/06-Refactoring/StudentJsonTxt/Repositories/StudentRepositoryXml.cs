using StudentJsonTxt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace StudentJsonTxt.Repositories
{
    public class StudentRepositoryXml : IStudentRepository
    {
        private readonly string _filePath;
        public StudentRepositoryXml(string filePath = "students.xml")
        {
            _filePath = filePath;
        }

        public void Save(List<Student> students)
        {
            var allData = new XmlSerializer(typeof(List<Student>));

            using (var steam = new FileStream(_filePath, FileMode.Create))
            {
                allData.Serialize(steam, students);
            }
        }

        public List<Student> Load()
        {
            var list = new List<Student>();
            if (!File.Exists(_filePath))
                return list;

            var allData = new XmlSerializer(typeof(List<Student>));

            using (var stream = new FileStream(_filePath, FileMode.Open))
            {
                var students = allData.Deserialize(stream) as List<Student>;
                return students;
            }

        }
    }
}
