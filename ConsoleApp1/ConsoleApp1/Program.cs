using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        public static List<Project> Projects = new List<Project>();
        public static void Main(string []args) 
        {

            Console.WriteLine("Добро пожалывать");
            //JsonBase jsonBase = new JsonBase();
            //Projects =  jsonBase.ReadJson(Projects);

            //Console.WriteLine(" # " + " | " + " Название " + " | " + " Дата начало " + " | " + " Статус " + " | " + " Преоритет ");
            //for (int i = 0; i < Projects.Count; i++)
            //{
                
            //    Console.WriteLine( (i + 1) + " | " + Projects[i].Name + " | " + Projects[i].StartDate + " | " + Projects[i].Status + " | " + Projects[i].Priority);
            
            //}

            SelectAction();

            
               
        }

        public static void SelectAction()
        {
            Console.WriteLine($"Выберите дейстие       | \n" +
                              $"1 . Выбрать проект     | \n" +
                              $"2 . Добавить проект    | \n" +
                              $"3 . Удалить проект     | \n" +
                              $"4 . Сохранить данные   | ");
            string number = Console.ReadLine();
            int action;

            bool success = int.TryParse(number, out action);
            if (success & (action > 0 & action < 5))
            {
                switch (action)
                {
                    case 1:
                        Console.WriteLine("Введите номер проекта");
                         number = Console.ReadLine();
                        int project;

                        success = int.TryParse(number, out project);
                        if (success & (project > 0 & project <= Projects.Count))
                        {
                            ActionsOnTheProject(project);
                        }
                        else
                        {
                            Console.WriteLine("Введите правильные данные");
                            SelectAction();
                        }
                        break;
                    case 2:
                        AddProject();
                        SelectAction();
                        break;
                    case 3:
                        Console.WriteLine("Введите проект который нужно удалить");
                        number = Console.ReadLine();

                        success = int.TryParse(number, out project);
                        if (success & (project > 0 & project <= Projects.Count))
                        {
                            DeletProject(project - 1);
                            SelectAction();
                        }
                        else
                        {
                            Console.WriteLine("Введите правильные данные");
                            SelectAction();
                        }
                        break;
                    case 4:
                        SaveChange();
                        SelectAction();
                        break;

                }
            }
            else
            {
                Console.WriteLine("Введите правильные данные");
                SelectAction();
            }
           

        }

        public static void ActionsOnTheProject(int project)
        {
            Console.WriteLine($"Выберите дейстие        | \n" +
                      $"1 . Добавить задачу             | \n" +
                      $"2 . Удалить задачу              | \n" +
                      $"3 . Установить приоритет задачи | \n" +
                      $"4 . Изменить статус задачи      | \n" +
                      $"5 . Посмотреть задачи           | \n" +
                      $"7 . Вернутся в главное меню     | \n" +
                      $"6 . Изменить описание задачи    | ");

            string number = Console.ReadLine();
            int action;

            bool success = int.TryParse(number, out action);
            if (success & (action > 0 & action < 8))
            {
                switch (action)
                {
                    case 1:
                        Projects[project - 1].AddTask();
                        ActionsOnTheProject(project);
                        break;
                    case 2:
                        int returnNumber = SelectTask(project);
                        if (returnNumber != 0)
                        {
                            Projects[project - 1].DeletTask(returnNumber);
                            ActionsOnTheProject(project);
                        }
                        else 
                        {
                            Console.WriteLine("Введите правильные данные");
                            ActionsOnTheProject(project);
                        }
                        break;
                    case 3:
                        returnNumber = SelectTask(project);
                        if (returnNumber != 0)
                        {
                            Projects[project - 1].SetPriorityOfTask(returnNumber);
                            ActionsOnTheProject(project);
                        }
                        else
                        {
                            Console.WriteLine("Введите правильные данные");
                            ActionsOnTheProject(project);
                        }
                        break;
                    case 4:
                         returnNumber = SelectTask(project);
                        if (returnNumber != 0)
                        {
                            Projects[project - 1].SetStatusOfTask(returnNumber);
                            ActionsOnTheProject(project);
                        }
                        else
                        {
                            Console.WriteLine("Введите правильные данные");
                            ActionsOnTheProject(project);
                        }
                        break;
                    case 5:
                        Projects[project - 1].ShowTasks();
                        ActionsOnTheProject(project);
                        break;
                    case 6:
                        returnNumber = SelectTask(project);
                        if (returnNumber != 0)
                        {
                            Projects[project - 1].ChangeDescriptionOfTask(returnNumber);
                            ActionsOnTheProject(project);
                        }
                        else
                        {
                            Console.WriteLine("Введите правильные данные");
                            ActionsOnTheProject(project);
                        }
                        break;
                    case 7:
                        SelectAction();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Введите правильные данные");
                ActionsOnTheProject(project);
            }
        }

        public static int SelectTask(int project)
        {
            Console.WriteLine("Введите номер задачи");
            string number1 = Console.ReadLine();
            int numberOfTask;

            bool success = int.TryParse(number1, out numberOfTask);
            if (success & (numberOfTask > 0 & numberOfTask <= Projects[project - 1].Tasks.Count))
            {
                return numberOfTask;
            }
            else
            {
                return 0;
            }
        }

        public static void SaveChange() 
        {
            JsonBase jsonBase = new JsonBase();
            jsonBase.WriteJson(Projects);
            Console.WriteLine("Проекты сохранены");
        }

        public static void DeletProject(int number)
        {
            Projects.RemoveAt(number);
            Console.WriteLine("Проект удален");
        }

        public static void AddProject()
        {
            Console.WriteLine("Введите название проекта");
            string name = Console.ReadLine();

            Console.WriteLine("Введите приоритетность проекта(от 1 до 3)");
            string number = Console.ReadLine();
            int priority;

            bool success = int.TryParse(number, out priority);
            if (success & (priority > 0 & priority < 4))
            {
                Projects.Add(new Project(name, priority , new List<Task>()));
                Console.WriteLine("Проект добавлен");
            }
            else
            {
                Console.WriteLine("Введите правильные данные");
                AddProject();
            }
        }
    }
}

