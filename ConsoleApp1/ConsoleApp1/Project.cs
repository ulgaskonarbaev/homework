using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
     public class Project
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }

        public DateTime CompletionData { get; set; }

        public string Status { get; set; }

        public int Priority { get; set; }

        public List<Task> Tasks ;

        public Project(string name , int priority, List<Task> tasks ) 
        {
            this.Name = name;
            this.Priority = priority;
            this.Status = "ToDo";
            this.StartDate = DateTime.Now;
            this.Tasks = tasks;

        }

        public void SetStatusOfTask(int numberOfTask) 
        {
            this.Tasks[numberOfTask-1].SetStatus();
            for (int i = 0; i < this.Tasks.Count; i++)
            {
                if (this.Status == "ToDo" & this.Tasks[i].Status == "Active")
                {
                    this.Status = "InProgress";
                }
                else if (this.Status == "ToDo" & this.Tasks[i].Status == "NotStarted")
                { 
                
                }
                else if (this.Status == "InProgress" & (this.Tasks[i].Status == "Active" | this.Tasks[i].Status == "NotStarted"))
                {
                
                }
                else
                {
                    this.Status = "Done";
                    this.CompletionData = DateTime.Now;
                    Console.WriteLine("Проект завершен. Поздравляю !!!");
                }
                
            }


             
            
        }
        public void DeletTask(int task)
        {
            this.Tasks.RemoveAt(task);
        }
        public void SetPriority() 
        {
            Console.WriteLine("Выберите приоритетность проекта(есть 3 номера приоритета)");

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

        public void ShowTasks()
        {
            for (int i = 0; i < this.Tasks.Count; i++) 
            {
                Console.WriteLine("Name  " + " | " + "Status  " + " | " + "Priority  " + " | " + "Description  ");
                Console.WriteLine( (i + 1) + " | " + this.Tasks[i].Name + " | " + this.Tasks[i].Status + " | " + this.Tasks[i].Priority + " | " + this.Tasks[i].Description);
            }
        
        }

        public void ChangeDescriptionOfTask(int numberOfTask)
        {
            this.Tasks[numberOfTask - 1].ChangeDescription();
        }

        public void SetPriorityOfTask(int numberOfTask)
        {
            this.Tasks[numberOfTask - 1].SetPriority();
        }

        public void AddTask()
        {
            Console.WriteLine("Введите название задачи");
            string name = Console.ReadLine();

            Console.WriteLine("Введите описание задачи");
            string discription = Console.ReadLine();

            Console.WriteLine("Введите приоритетность задачи(от 1 до 3)");
            string number = Console.ReadLine();
            int priority;

            bool success = int.TryParse(number, out priority);
            if (success & (priority > 0 & priority < 4 ))
            {
                this.Tasks.Add(new Task(name, discription, priority));
                Console.WriteLine("Задача добавлена");
            }
            else
            {
                Console.WriteLine("Введите правильные данные");
                AddTask();
            }

           
        }
    }
}
