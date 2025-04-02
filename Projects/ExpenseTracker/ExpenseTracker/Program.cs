using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using static ExpenseTracker.Program;

namespace ExpenseTracker
{
    internal class Program
    {

        public class Expense
        {
            public Expense(decimal amount, string description, string category, DateTime date)
            {
                Amount = amount;
                Description = description;
                Category = category;
                Date = date;
            }

            public decimal Amount { get; set; }
            public string Description { get; set; }
            public string Category { get; set; }
            public DateTime Date { get; set; }
        }

        static void Main(string[] args)
        {
            List<Expense> expenseList = new();
            Console.WriteLine("----Welcome to the expense tracker!----");
            string action = string.Empty;
            while (true)
            {
                action = ChooseAction();
                switch (action)
                {
                    case "1":
                        EnterExpenses(expenseList);
                        break;
                    case "2":
                        CategorizeExpenses(expenseList);
                        break;
                    case "3":
                        MonthlyBudgeting(expenseList);
                        break;
                    case "4":
                        ViewReports(expenseList);
                        break;
                    case "5":

                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again!");
                        break;
                }
                Console.Write("Do you want to continue? Y/N: ");
                action = Console.ReadLine();
            }
        }

        static void CategorizeExpenses(List<Expense> expenseList)
        {
            Console.Clear();

            if (DisplayExpenses(expenseList)) return;

            Console.Write("Enter the number to categorize: ");
            int expenseNumber = int.Parse(Console.ReadLine());

            if (CheckExpenseNumber(expenseList, expenseNumber)) return;

            Expense expense = expenseList[expenseNumber - 1];

            Console.Write("Enter your category: ");
            string category = Console.ReadLine();

            expense.Category = category;

            Console.WriteLine("Expense categorized successfully!");
        }

        private static bool CheckExpenseNumber(List<Expense> expenseList, int expenseNumber)
        {
            if (expenseNumber < 1 || expenseNumber > expenseList.Count)
            {
                Console.WriteLine("Invalid expense number!");
                return true;
            }

            return false;
        }

        private static bool DisplayExpenses(List<Expense> expenseList)
        {
            if (expenseList.Count == 0)
            {
                Console.WriteLine("No expenses found!");
                return true;
            }

            Console.WriteLine("Expense list:");
            for (int i = 0; i < expenseList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Amount: {expenseList[i].Amount}, Description: {expenseList[i].Description}");
            }

            return false;
        }

        private static void EnterExpenses(List<Expense> expenseList)
        {
            Console.Clear();
            Console.Write("Enter the amount: ");
            decimal amount = decimal.Parse(Console.ReadLine());
            Console.Write("Enter the description: ");
            string description = Console.ReadLine();
            Console.Write("Enter the category: ");
            string category = Console.ReadLine();
            DateTime date = DateTime.Now;

            expenseList.Add(new Expense(amount, description, category, date));

            Console.WriteLine("Expense entered successfully!");
        }

        static string ChooseAction()
        {
            Console.Clear();
            Console.WriteLine("1 - Enter Expenses!");
            Console.WriteLine("2 - Categorize Expenses!");
            Console.WriteLine("3 - Monthly Budgeting!");
            Console.WriteLine("4 - Visual Charts!");
            Console.WriteLine("5 - Data Filtering");
            Console.Write("Choose your action: ");
            string action = Console.ReadLine();
            return action;
        }
        static void MonthlyBudgeting(List<Expense> expenseList)
        {
            Console.Clear();
            Console.WriteLine("==== Monthly Budgeting ====");

            if (DisplayExpenses(expenseList)) return;

            Console.Write("Enter the month (1-12): ");
            int month = int.Parse(Console.ReadLine());

            if (month < 1 || month > 12)
            {
                Console.WriteLine("Invalid month number.");
                return;
            }

            Console.Write("Enter the year: ");
            int year = int.Parse(Console.ReadLine());

            decimal totalExpense = expenseList
                .Where(e => e.Date.Month == month && e.Date.Year == year)
                .Sum(e => e.Amount);

            Console.WriteLine($"Total expenses for {month}/{year}: {totalExpense}");
        }
        static void ViewReports(List<Expense> expenseList)
        {
            Console.Clear();
            Console.WriteLine("==== View Reports ====");

            if (DisplayExpenses(expenseList)) return;

            Console.Write("Enter the category to view expenses: ");
            string category = Console.ReadLine();

            List<Expense> categoryExpenses = expenseList
                .Where(e => e.Category == category)
                .ToList();

            if (categoryExpenses.Count == 0)
            {
                Console.WriteLine("No expenses found for the category.");
                return;
            }

            Console.WriteLine($"Expenses for Category: {category}");
            foreach (var expense in categoryExpenses)
            {
                Console.WriteLine($"Amount: {expense.Amount}, Description: {expense.Description}");
            }
        }
    }
}
