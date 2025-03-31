using System;

namespace RockPaperScissorsGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----Welcome to Rock/Paper/Scissors game!----");
            Console.WriteLine("1 - Rock!");
            Console.WriteLine("2 - Paper!");
            Console.WriteLine("3 - Scissors");

            string[] actions = { "rock", "paper", "scissors" };

                Console.Write("Select your choice: ");

                string choice = Console.ReadLine();

                string randomChoice = GetPcChoice(actions);

                switch (choice)
                {
                    case "1":
                        RockOutcomes(randomChoice);
                        break;
                    case "2":
                        PaperOutcomes(randomChoice);
                        break;
                    case "3":
                        ScissorsOutcomes(randomChoice);
                        break;
                }
        }

        private static void ScissorsOutcomes(string randomChoice)
        {
            if (randomChoice == "rock")
            {
                Console.WriteLine("The PC threw rock!");
                Console.WriteLine("You threw scissors!");
                Console.WriteLine("You lose!");
            }
            else if (randomChoice == "paper")
            {
                Console.WriteLine("The PC threw paper!");
                Console.WriteLine("You threw scissors!");
                Console.WriteLine("You win!");
            }
            else if (randomChoice == "scissors")
            {
                Console.WriteLine("The PC threw scissors!");
                Console.WriteLine("You threw scissors!");
                Console.WriteLine("It's a draw!");
            }
        }

        private static void PaperOutcomes(string randomChoice)
        {
            if (randomChoice == "rock")
            {
                Console.WriteLine("The PC threw rock!");
                Console.WriteLine("You threw paper!");
                Console.WriteLine("You win!");
            }
            else if (randomChoice == "paper")
            {
                Console.WriteLine("The PC threw paper!");
                Console.WriteLine("You threw paper!");
                Console.WriteLine("It's a draw!");
            }
            else if (randomChoice == "scissors")
            {
                Console.WriteLine("The PC threw scissors!");
                Console.WriteLine("You threw paper!");
                Console.WriteLine("You lose!");
            }
        }

        private static void RockOutcomes(string randomChoice)
        {
            if (randomChoice == "rock")
            {
                Console.WriteLine("The PC threw rock!");
                Console.WriteLine("You threw rock!");
                Console.WriteLine("It's a draw!");
            }
            else if (randomChoice == "paper")
            {
                Console.WriteLine("The PC threw paper!");
                Console.WriteLine("You threw rock!");
                Console.WriteLine("You lose!");
            }
            else if (randomChoice == "scissors")
            {
                Console.WriteLine("The PC threw scissors!");
                Console.WriteLine("You threw rock!");
                Console.WriteLine("You win!");
            }
        }

        static string GetPcChoice(string[] actions)
        {
            Random random = new Random();
            return actions[random.Next(actions.Length)];
        }
    }
}
