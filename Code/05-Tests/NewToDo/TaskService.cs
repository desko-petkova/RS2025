using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewToDo
{
    public class TaskService
    {
        private readonly TaskRepository repository; // Връзка с слоя за достъп до данни.
        private List<Todo> tasks; // Локален списък от задачи, който държи текущото състояние в паметта.

        public TaskService()
        {
            this.repository = new TaskRepository(); // Инициализация на репозитори обекта.
            tasks = repository.LoadTasks(); // Зареждане на съществуващите задачи от файл.
        }

        public List<Todo> GetAllTasks()
        {
            return tasks; // Връща всички текущи задачи.
        }

        public void AddTask(string taskName)
        {
            // Проверка за валидност на въведеното име.
            if (string.IsNullOrWhiteSpace(taskName) || taskName.Length < 3)
                throw new ArgumentException("The task's name must contain a minimum of 3 characters.");

            tasks.Add(new Todo(taskName, false)); // Добавяне в локалния списък.
            repository.SaveTasks(tasks); // Добавяне и във файла чрез слоя за достъп до данни.
        }

        public void RemoveTask(int index)
        {
            // Проверка за валиден индекс.
            if (index < 0 || index >= tasks.Count)
                throw new ArgumentException("Invalid index.");

            tasks.RemoveAt(index); // Изтриване от списъка.
            repository.SaveTasks(tasks); // Презаписване на файла с актуализирания списък.
        }

        public void Update(int index, string taskName)
        {
            // Проверка за валиден индекс.
            if (index < 0 || index >= tasks.Count)
                throw new ArgumentException("Invalid index.");
            // Проверка за валидност на въведеното име.
            if (string.IsNullOrWhiteSpace(taskName) || taskName.Length < 3)
                throw new ArgumentException("The task's name must contain a minimum of 3 characters.");

            tasks[index].Name = taskName;
            repository.SaveTasks(tasks);
        }
        public void StatusChange(int index)
        {
            // Проверка за валиден индекс.
            if (index < 0 || index >= tasks.Count)
                throw new ArgumentException("Invalid index.");

            tasks[index].IsCompleted = !tasks[index].IsCompleted;
            repository.SaveTasks(tasks);
        }
    }
}
