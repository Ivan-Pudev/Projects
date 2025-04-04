using System;
using System.Threading;

namespace StudentGradebookSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GradeBook gradeBook = new();

            string action = string.Empty;
            while (action != "end")
            {
                Console.WriteLine("----Welcome to student gradebook system!----");
                Console.WriteLine("\n1 - Register student!\n2 - Add grades!" +
                                  "\n3 - Calculate performance!\n4 - Get report!");
                Console.Write("Enter the corresponding number of your choice: ");
                char choice = char.Parse(Console.ReadLine());
                Console.Clear();

                switch (choice)
                {
                    case '1':
                        Console.Write("Enter name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter ID: ");
                        string iD = Console.ReadLine();

                        Student student = new(name, iD);
                        gradeBook.AddStudent(student);
                        Console.WriteLine("Successfully added student!");
                        break;
                    case '2':
                        if (gradeBook.Students.Count == 0)
                        {
                            Console.WriteLine("There are no students.");
                            break;
                        }

                        foreach (Student studentValue in gradeBook.Students)
                        {
                            Console.WriteLine($"{studentValue}");

                            foreach (string subject in gradeBook.Subjects)
                            {
                                Console.Clear();
                                Console.Write("Enter count of grades: ");
                                int count = int.Parse(Console.ReadLine());
                                Console.WriteLine($"{subject}: ");
                                Console.WriteLine("Enter Grades from 2 to 6: ");

                                for (int i = 0; i < count; i++)
                                {
                                    Console.Write("Enter grade: ");
                                    int grade = int.Parse(Console.ReadLine());
                                    gradeBook.AssignGrade(studentValue.StudentId, subject, grade);
                                }

                            }
                        }
                        break;
                    case '3':
                        if (gradeBook.Students.Count == 0)
                        {
                            Console.WriteLine("There are no students.");
                            break;
                        }

                        foreach (Student studentValue in gradeBook.Students)
                        {
                            double average = studentValue.GetAverageGrade();
                            Console.WriteLine(average);
                        }
                        break;
                    case '4':
                        if (gradeBook.Students.Count == 0)
                        {
                            Console.WriteLine("There are no students.");
                            break;
                        }

                        foreach (Student studentValue in gradeBook.Students)
                        {
                            Console.WriteLine($"{studentValue}");
                        }

                        Console.Write("Enter ID: ");
                        iD = Console.ReadLine();
                        gradeBook.GenerateReport(iD);
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }

                Console.WriteLine("\nEnter 'end' to exit or click anything to continue.");
                action = Console.ReadLine().ToLower();
            }
        }
    }
}
