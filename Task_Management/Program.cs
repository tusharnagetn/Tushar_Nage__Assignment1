using System;
using System.Collections.Generic;
using Task_Management.Models;

namespace Task_Management
{
    public class Program
    {
        static List<Task> myTask = new List<Task>();

        static void Main(string[] args)
        {
            Console.WriteLine("<======================= SIMPLE TASK LIST APPLICATION =======================>");

            //Adding dummy data 
            myTask.Add(new Task { Title = "Develop API", Description = "Make crud operation on employee table" });
            myTask.Add(new Task { Title = "Push code", Description = "Push code on git and deploy latest version on server" });
            myTask.Add(new Task { Title = "Meeting", Description = "Meeting with client at 5:30 PM about the new features in project" });

            Menu();
        }

        /// <summary>
        /// Static method to show menu bar on console.
        /// </summary>
        public static void Menu()
        {
            Console.WriteLine();
            Console.WriteLine("--------------------> MENU <--------------------");
            Console.WriteLine("[1] : Add Task,  [2] : Remove Task,  [3] : Update Task, [4] : View All Task, [5] : Exit");
            try
            {
                int execute = Convert.ToInt32(Console.ReadLine());
                switch (execute)
                {
                    case 1: AddTask();     break;
                    case 2: RemoveTask();  break;
                    case 3: UpdateTask();  break;
                    case 4: ViewAllTask(); break;
                    case 5: Exit();        break;
                    default: Console.WriteLine("Invalid Input re-enter valid input"); Menu(); break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid Input re-enter valid input as number ");
                Menu();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        /// <summary>
        /// Static method to add new Task data in List.
        /// </summary>
        public static void AddTask()
        {
            Console.WriteLine("--------------------> Add Task <--------------------");
            Console.WriteLine("[1] : Add, [0] : Back to Menu");
            int value = Convert.ToInt32(Console.ReadLine());
            if (value == 1)
            {
                Console.Write("Enter Title : ");
                string title = Console.ReadLine();

                Console.Write("Enter Description : ");
                string Description = Console.ReadLine();

                myTask.Add(new Task { Title = title, Description = Description });

                Console.WriteLine("Task added successfully");
                AddTask();
            }
            else if(value == 0)
            {
                Menu();
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
        }

        /// <summary>
        /// Static method to remove Task data in List.
        /// </summary>
        public static void RemoveTask()
        {
            Console.WriteLine("--------------------> Remove Task <--------------------");
            Console.WriteLine("[1] : Remove, [0] : Back to Menu");

            int value = Convert.ToInt32(Console.ReadLine());
            if (value == 1)
            {
                for (int i = 0; i < myTask.Count; i++)
                {
                    Console.WriteLine("[" + (i + 1) + "] : " + myTask[i].Title + " - " + myTask[i].Description);
                }
                
                try
                {
                    Console.Write("Enter no. to delete Task : ");
                    int index = Convert.ToInt32(Console.ReadLine());
                    myTask.RemoveAt(index - 1);
                    Console.WriteLine("Task deleted successfully");
                    RemoveTask();
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid Input re-enter valid input as number ");
                    RemoveTask();
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Data not found");
                    RemoveTask();
                }
            }
            else if (value == 0)
            {
                Menu();
            }
            else
            {
                Console.WriteLine("Invalid input");
            }

        }

        /// <summary>
        /// Static method to update existing data in List.
        /// </summary>
        public static void UpdateTask()
        {
            Console.WriteLine("--------------------> Update Task <--------------------");

            Console.WriteLine("[1] : Update, [0] : Back to Menu");

            int value = Convert.ToInt32(Console.ReadLine());
            if (value == 1)
            {
                for (int i = 0; i < myTask.Count; i++)
                {
                    Console.WriteLine("[" + (i + 1) + "] : " + myTask[i].Title + " - " + myTask[i].Description);
                }

                Console.Write("Enter no. to update Task : ");
                try
                {
                    int index = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter Title : ");
                    string title = Console.ReadLine();

                    Console.Write("Enter Description : ");
                    string Description = Console.ReadLine();

                    myTask[index - 1].Title = title;
                    myTask[index - 1].Description = Description;

                    Console.WriteLine("Task updated successfully");
                    UpdateTask();
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid Input re-enter valid input as number ");
                    UpdateTask();
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Data not found");
                    UpdateTask();
                }

                Console.WriteLine("Task updated successfully");
            }
            else if (value == 0)
            {
                Menu();
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
        }

        /// <summary>
        /// Static method to show complete list of Task data.
        /// </summary>
        public static void ViewAllTask()
        {
            Console.WriteLine("--------------------> List of Task <--------------------");
            if (myTask.Count != 0)
            {
                for (int i = 0; i < myTask.Count; i++)
                {
                    Console.WriteLine("[" + (i + 1) + "] : " + myTask[i].Title + " - " + myTask[i].Description);
                }
            }
            else
            {
                Console.WriteLine("Data not found");
            }

            Menu();
        }

        /// <summary>
        /// Static method to exit from console app.
        /// </summary>
        public static void Exit()
        {
            Console.Clear();
        }
    }
}
