// See https://aka.ms/new-console-template for more information
using System.Drawing;
using Pastel;
public class ToDoList
{
    private const int taskMaxLength = 10;
    static string[] tasks = new string[taskMaxLength];
    static int taskCount = 0;

    public static void CompleteTask()
    {
        Console.WriteLine($"Enter the number of the task you want to mark as completed (1 to {taskMaxLength}):");
        int taskNumber;
        if (int.TryParse(Console.ReadLine(), out taskNumber) && taskNumber >= 1 && taskNumber <= tasks.Length)
        {
            if (!string.IsNullOrEmpty(tasks[taskNumber - 1]))
            {
                tasks[taskNumber - 1] += " (Completed)";
                Console.WriteLine($"Task {taskNumber} marked as completed!");
            }
            else
            {
                Console.WriteLine("The selected task is empty. Please select a valid task.");
            }
        }
        else
        {
            Console.WriteLine($"Invalid input. Please enter a number between 1 and {taskMaxLength}.");
        }
    }
    public static void ViewTasks()
    {
        Console.WriteLine("this is ur todo list");
        for (int i = 0; i < tasks.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {tasks[i]}");
        }
    }
    public static void AddTask()
    {
        while (taskCount < tasks.Length)
        {
            Console.WriteLine("Enter a new task:");
            string? newTask = Console.ReadLine();
            if (!string.IsNullOrEmpty(newTask))
            {
                tasks[taskCount] = newTask;
                taskCount++;
                Console.WriteLine("Task added successfully!");
            }
            else
            {
                Console.WriteLine("Task can't be empty!");
            }
        }

        Console.WriteLine("Task list is full. Cannot add more tasks.");

    }
    public static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nTo-Do List Menu:");
            Console.WriteLine("1. Add a Task");
            Console.WriteLine("2. View Tasks");
            Console.WriteLine("3. Complete a Task");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddTask();
                    break;
                case "2":
                    ViewTasks();
                    break;
                case "3":
                    CompleteTask();
                    break;
                case "4":
                    Console.WriteLine("Exiting the program. Goodbye!");
                    return; // Exit the loop and program
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}