using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewToDo
{
    public class Todo
    {
        public string Name { get; set; }
        public bool IsCompleted { get; set; }

        public Todo(string name, bool isCompleted = false)
        {
            Name = name;
            IsCompleted = isCompleted;
        }

        public override string ToString() 
        {
            string status = IsCompleted ? "[V] Completed" : "[X] Not done";
            return $"{Name} - {status}";
        }
    }
}
