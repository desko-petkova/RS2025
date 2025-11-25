using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewToDo
{
    public class TaskRepository
    {
        private readonly string filePath = "tasks.txt"; // Пътят до файла, където се съхраняват задачите.

        public List<Todo> LoadTasks()
        {
            var list = new List<Todo>();
            if (!File.Exists(filePath)) // Проверява дали файлът съществува.
                return list;

            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines) 
            {
                var part = line.Split(';');
                if(part.Length == 2)
                {
                    string name = part[0];
                    bool status = bool.Parse(part[1]);
                    list.Add(new Todo(name, status));
                }
                else
                {
                    list.Add(new Todo(line,false));
                }
            }
            return list;

        }

        public void SaveTasks(List<Todo> tasks)
        {
            var lines = new List<string>();
            foreach (var t in tasks) 
            {
                lines.Add($"{t.Name};{t.IsCompleted}");
            }
            File.WriteAllLines(filePath, lines); // Записва всички задачи наново във файла (използва се при изтриване).
        }

        //public void AppendTask(string taskName)
        //{
        //    File.AppendAllText(filePath, taskName); // Добавя нова задача към края на файла.
        //}
    }
}
