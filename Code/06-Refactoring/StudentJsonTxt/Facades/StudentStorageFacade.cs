using StudentJsonTxt.Models;
using StudentJsonTxt.Repositories;

namespace StudentJsonTxt.Facades
{

    public class StudentStorageFacade
    {
        private readonly IStudentRepository txtRepo;
        private readonly IStudentRepository jsonRepo;
        private readonly IStudentRepository xmlRepo;

        public StudentStorageFacade()
        {
            txtRepo = new StudentRepositoryTxt();
            jsonRepo = new StudentRepositoryJson();
            xmlRepo = new StudentRepositoryXml();
        }

        public void SaveAsTxt(List<Student> students)
        {
            txtRepo.Save(students);
        }

        public List<Student> LoadFromTxt()
        {
            return txtRepo.Load();
        }

        public void SaveAsJson(List<Student> students)
        {
            jsonRepo.Save(students);
        }

        public List<Student> LoadFromJson()
        {
            return jsonRepo.Load();
        }

        public void SaveAsXml(List<Student> students)
        {
            xmlRepo.Save(students);
        }

        public List<Student> LoadFromXml()
        {
            return xmlRepo.Load();
        }
    }
}
