using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentJsonTxt.Models
{
    public class Student
    {
        private string name;
        private int grade;

        public string Name { get; set; }
        public int Grade { get; set; }

        public Student() { }
        public Student(string name, int grade)
        {
            Name = name;
            Grade = grade;
        }

        public override string ToString()
        {
            return $"{Name} - {Grade}";
        }

    }
}
