using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;

namespace EmployeePayrollSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, Employee> employees = new();
            EmployeeManager manager = new ();
            Console.WriteLine("----Welcome to the employee payroll system!----");
            string action = ChooseAction();

            for (int j = 0; j < 5; j++)
            {
                switch (action)
                {
                    case "1":
                        Console.Write("Enter ID: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Enter Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter Department: ");
                        string dept = Console.ReadLine();
                        Console.Write("Enter Salary: ");
                        double salary = double.Parse(Console.ReadLine());

                        manager.AddEmployee(new Employee(salary,name,dept, id));
                        break;
                    case "2":
                        Console.Write("Enter Employee ID to remove: ");
                        int removeId = int.Parse(Console.ReadLine());
                        manager.RemoveEmployee(removeId);
                        break;
                    case "3":
                        Console.Write("Enter Employee ID: ");
                        int updateId = int.Parse(Console.ReadLine());
                        Console.Write("Enter new Salary: ");
                        double newSalary = double.Parse(Console.ReadLine());
                        manager.UpdateSalary(updateId, newSalary);
                        break;
                    case "4":
                        Console.Write("Enter Name Pattern to Search: ");
                        string pattern = Console.ReadLine();
                        manager.SearchEmployee(pattern);
                        break;
                    case "5":
                        manager.DisplayAllEmployees();
                        break;
                    case "6":
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        return;
                }

                action = ChooseAction();
            }
        }

        static string ChooseAction()
        {
            Console.WriteLine("1 - Add employee!");
            Console.WriteLine("2 - Remove employee!");
            Console.WriteLine("3 - Update employee salary!");
            Console.WriteLine("4 - Search employee!");
            Console.WriteLine("5 - List all employees");
            Console.WriteLine("6 - Calculate payroll!");
            Console.Write("Enter the corresponding number to your action: ");
            string action = Console.ReadLine();
            return action;
        }
    }
}
