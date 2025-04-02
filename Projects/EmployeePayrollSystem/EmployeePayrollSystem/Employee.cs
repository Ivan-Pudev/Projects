using System;
using System.Collections.Generic;

namespace EmployeePayrollSystem
{
    public class Employee
    {
        public Employee(double salary, string name, string department, int id)
        {
            Salary = salary;
            Name = name;
            Department = department;
            Bonus = 0;
            Id = id;
        }

        public int Id { get; set; } 
        public double Salary { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public double Bonus { get; set; }

        public void DisplayEmployee()
        {
            Console.WriteLine($"ID: {Id}, Name: {Name}, Department: {Department}, Salary: {Salary:C}, Bonus: {Bonus:C}");
        }
    }
}
