using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*****Calculator*****\n");
            Console.WriteLine("+ - Add");
            Console.WriteLine("- - Subtract");
            Console.WriteLine("* - Multiply");
            Console.WriteLine("/ - Divide");

            string answer = string.Empty;
            while (answer != "No")
            {
                Console.Write($"\nChoose your operation: ");
                if (!char.TryParse(Console.ReadLine(), out char operation))
                {
                    Console.WriteLine("Invalid number");
                    continue;
                }

                Console.Write($"Enter the first number: ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal first))
                {
                    Console.WriteLine("Invalid number");
                    continue;
                }

                Console.Write($"Enter the second number: ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal second))
                {
                    Console.WriteLine("Invalid number");
                    continue;
                }

                decimal result = 0;
                CalculateValue(operation, result, first, second);

                Console.WriteLine("Do you want to continue: Yes/No");
                answer = Console.ReadLine();
            }
        }

         static void CalculateValue(char operation, decimal result, decimal first, decimal second)
        {
            switch (operation)
            {
                case '+':
                    result = first + second;
                    break;
                case '-':
                    result = first - second;
                    break;
                case '*':
                    result = first * second;
                    break;
                case '/':
                    if (second == 0)
                    {
                        Console.WriteLine("Error: division by zero");
                        return;
                    }
                    else
                    {
                        result = first / second;
                    }
                    result = first / second;
                    break;
                default:
                    Console.WriteLine("Invalid operator");
                    break;
            }

            Console.WriteLine($"{first} {operation} {second} = {result}");
        }
    }
}
