using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Task
    {
        public string Name { get; set; }

        public string Status { get; set; }

        public string Description { get; set; }

        public int Priority { get; set; }

        public Task(string name, string description, int priority)
        {
            this.Name = name;
            this.Description = description;
            this.Priority = priority;
            this.Status = "NotStarted";
        }

        public void SetStatus()
        {
            if (this.Status == "NotStarted")
            {
                this.Status = "Active";
                Console.WriteLine("Статус задачи изменен"); 
            }
            else if (this.Status == "Active")
            {
                this.Status = "Completed";
                Console.WriteLine("Статус задачи изменен");
            }
            else Console.WriteLine("Задача завершена,поменять ее статус невозможно");


        }

        public void ChangeDescription()
        {
            Console.WriteLine("Введите описание задачи");
            this.Description = Console.ReadLine();
            Console.WriteLine("Описание задачи изменено");
        }

        public void SetPriority()
        {
            Console.WriteLine("Выберите приоритетность задачи(есть 3 номера приоритета)");

            string priority = Console.ReadLine();

            Dictionary<string, int> dictionary = new Dictionary<string, int>()
            {
              { "1", 1},
              { "2", 2},
              { "3", 3}
            };
            if (dictionary.ContainsKey(priority))
            {
                this.Priority = dictionary[priority];
                Console.WriteLine("Изменение успешно внесены");
            }
            else
            {
                Console.WriteLine("Введите верные данные");
                SetPriority();
            }
        }
    }
}
