using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;

namespace StudentGradebookSystem
{
    public class GradeBook
    {
        public List<Student> Students { get; set; } = new();
        public string[] Subjects { get; set; } = { "Math", "Science", "English" };
        public void AddStudent(Student student)
        {
            if (!Students.Contains(student))
            {
                Students.Add(student);
                Console.WriteLine("Successfully added student.");
                return;
            }

            Console.WriteLine("Student already exists");
        }

        public void AssignGrade(string studentId, string subject, int grade)
        {
            List<int> grades = new();

            foreach (Student student in Students)
            {
                grades.Add(grade);
                if (!student.Grades.ContainsKey(subject))
                {
                    student.Grades.Add(subject,grades);
                    return;
                }
                student.Grades[subject].Add(grade);
            }
        }

        public void GenerateReport(string studentId)
        {
            Student student = Students.Find(s => s.StudentId == studentId);
            
            Console.WriteLine($"\n--- Report for {student.Name} ({student.StudentId}) ---");

            foreach (var subject in Subjects)
            {
                double avg = student.GetAverageForSubject(subject);
                Console.WriteLine($"{subject}: Average = {avg:F2}");
            }
            Console.WriteLine($"Overall Average: {student.GetAverageGrade():F2}");
            Console.WriteLine(student.IsPassing(60) ? "Status: PASS" : "Status: FAIL");
        }
    }
}
