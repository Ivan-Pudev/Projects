using System;
using System.Linq;
using System.Text;

namespace HangManGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-----Welcome!!!-----");

            string[] words =
            {
                "apple", "banana", "cherry", "dragonfruit", "elderberry", "fig", "grape"
                ,"berries","cucumber","pineapple"

            };
            Random random = new Random();
            string randomWord = words[random.Next(words.Length)];
            int lives = 6;
            StringBuilder wordToGuess = new(randomWord.Length);

            for (int i = 0; i < randomWord.Length; i++)
            {
                wordToGuess.Append("-");
            }

            Console.WriteLine("Guess the word, you have 6 lives!");

            while (lives > 0)
            {
                Console.WriteLine("Suggest a letter!");
                if (char.TryParse(Console.ReadLine(), out char letter))
                {
                    if (randomWord.Contains(letter))
                    {
                        FindLetterPosition(randomWord, letter, wordToGuess);

                        if (wordToGuess.ToString() == randomWord)
                        {
                            Console.WriteLine("You won!");
                            return;
                        }
                    }
                    else
                    {
                        Console.WriteLine("No matches!");
                        lives--;
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect input!");
                    lives--;
                }

                Console.WriteLine(wordToGuess.ToString());
            }

            Console.WriteLine("You lost!");
        }

         static void FindLetterPosition(string randomWord, char letter, StringBuilder wordToGuess)
        {
            for (int i = 0; i < randomWord.Length; i++)
            {
                char character = randomWord[i];
                if (character == letter)
                {
                    wordToGuess.Insert(i, letter);
                    wordToGuess.Remove(i + 1, 1);
                }
            }
        }
    }
}
