using System;

namespace GuessingGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----Welcome to the Guessing Game!!!----");
            Console.WriteLine("Guess the secret number between 1 and 100.");

            Random random = new Random();
            int numberToGuess = random.Next(1, 101);
            int guess = 0;
            int count = 0;

            while (guess != numberToGuess)
            {
                Console.Write("Enter your guess: ");
                guess = int.Parse(Console.ReadLine());

                if (guess > 100 || guess <= 0)
                {
                    Console.WriteLine("Invalid guess!");
                    count++;
                    continue;
                }

                if (guess > numberToGuess)
                {
                    Console.WriteLine("Your guess is too high!");
                }
                else
                {
                    Console.WriteLine("Your guess is too low!");
                }

                count++;
            }
            Console.WriteLine($"You have guessed the number in {count} tries");
        }
    }
}
