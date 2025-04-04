using System.Collections.Generic;
using System.Linq;

namespace StudentGradebookSystem
{
    public class Student
    {
        public Student(string name, string studentId)
        {
            Name = name;
            StudentId = studentId;
            Grades = new();
        }
        public string Name { get; set; }
        public string StudentId { get; set; }
        public Dictionary<string, List<int>> Grades { get; set; }

        public void AddGrade(string subject, int grade)
        {
            if (!Grades.ContainsKey(subject))
                Grades[subject] = new List<int>();
            Grades[subject].Add(grade);
        }
        public double GetAverageGrade()
        {
            //var average = Grades.Values.Average(g => g.Count);
            //return average;
            int total = 0;
            int count = 0;
            foreach (var subject in Grades)
            {
                total += subject.Value.Sum();
                count += subject.Value.Count;
            }
            return count == 0 ? 0 : (double)total / count;
        }
        public double GetAverageForSubject(string subject)
        {
            if (!Grades.ContainsKey(subject) || Grades[subject].Count == 0)
                return 0;
            return Grades[subject].Average();
        }

        public bool IsPassing(double threshold)
        {
            return GetAverageGrade() >= threshold;
        }
        public override string ToString()
        {
            return $"Name: {Name}, ID: {StudentId}";
        }
    }
}
