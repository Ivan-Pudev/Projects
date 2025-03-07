using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace _04.Students
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int count = int.Parse(Console.ReadLine());
            List<Student> students = new List<Student>();
            for (int i = 0; i < count; i++)
            {
                string[] arguments = Console.ReadLine().Split(" ");
                Student student = new(arguments[0], arguments[1], double.Parse(arguments[2]));
                students.Add(student);
            }
            students = students.OrderByDescending(s => s.Grade).ToList();

            foreach (Student student in students)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName}: {student.Grade:f2}");
            }
        }
    }
    public class Student
    {
        public Student(string firstName, string lastName, double grade)
        {
            FirstName = firstName;
            LastName = lastName;
            Grade = grade;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Grade { get; set; }
    }
}
