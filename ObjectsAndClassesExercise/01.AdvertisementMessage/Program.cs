using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.AdvertisementMessage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            List<string> phrases = new() {"Excellent product.",
                        "Such a great product.",
                        "I always use that product.",
                        "Best product of its category.",
                        "Exceptional product.",
                        "I can't live without this product."};

            List<string> events = new() { "Now I feel good.",
                    "I have succeeded with this product.",
                    "Makes miracles. I am happy of the results!",
                    "I cannot believe but now I feel awesome.",
                    "Try it yourself, I am very satisfied.",
                    "I feel great!" };

            List<string> authors = new() { "Diana", "Petya",
                "Stella", "Elena", "Katya",
                "Iva", "Annie", "Eva" };

            List<string> cities = new() { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };

            Random rnd = new Random();

            for (int i = 0; i < count; i++)
            {
                int randomPhrase = rnd.Next(phrases.Count);
                int randomEvent = rnd.Next(events.Count);
                int randomAuthor = rnd.Next(authors.Count);
                int randomCity = rnd.Next(cities.Count);

                Console.WriteLine($"{phrases[randomPhrase]} {events[randomEvent]} {authors[randomAuthor]} – {cities[randomCity]}.");
            }
        }
    }
}
