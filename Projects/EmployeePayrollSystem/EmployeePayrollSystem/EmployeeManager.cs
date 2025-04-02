using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace EmployeePayrollSystem
{
    public class EmployeeManager
    {
        private Dictionary<int, Employee> employees = new Dictionary<int, Employee>();

        static bool DisplayEmployees(Dictionary<int, Employee> employees)
        {
            Console.Clear();
            if (employees.Count == 0)
            {
                Console.WriteLine("There are no employees!");
                return true;
            }

            Console.WriteLine("----Employee List----");

            foreach ((int iD, Employee employee) in employees)
            {
                Console.WriteLine($"ID: {iD} - {employee}");
            }

            return false;
        }

        public void AddEmployee(Employee employee)
        {
            if (!employees.ContainsKey(employee.Id))
            {
                employees.Add(employee.Id, employee);
                Console.WriteLine("Employee added successfully.");
            }
            else
            {
                Console.WriteLine("Employee ID already exists.");
            }
        }
        public void RemoveEmployee(int id)
        {
            if (employees.Remove(id))
            {
                Console.WriteLine("Employee removed successfully.");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }
        public void UpdateSalary(int id, double newSalary)
        {
            if (!employees.ContainsKey(id))
            {
                employees[id].Salary = newSalary;
                Console.WriteLine("Salary added successfully.");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }
        public void SearchEmployee(string namePattern)
        {
            var regex = new Regex(namePattern, RegexOptions.IgnoreCase);
            var results = employees.Values.Where(e => regex.IsMatch(e.Name)).ToList();

            if (results.Count > 0)
            {
                Console.WriteLine("\nSearch Results:");
                results.ForEach(e => e.DisplayEmployee());
            }
            else
            {
                Console.WriteLine("No employees found.");
            }
        }
        public void DisplayAllEmployees()
        {
            foreach (var emp in employees.Values)
            {
                emp.DisplayEmployee();
            }
        }
    }
}
