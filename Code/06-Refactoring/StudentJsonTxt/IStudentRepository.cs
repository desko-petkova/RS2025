using StudentJsonTxt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentJsonTxt
{
    public interface IStudentRepository
    {
        void Save(List<Student> students);
        List<Student> Load();
    }
}
