using System;

namespace _01.PasswordReset
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Done")
            {
                string[] tokens = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string action = tokens[0];
                string rawPassword = string.Empty;
                switch (action)
                {
                    case "TakeOdd":
                        for (int i = 1; i < password.Length; i+=2)
                        {
                            rawPassword += password[i];
                        }
                        password = rawPassword;
                        break;
                    case "Cut":
                        int index = int.Parse(tokens[1]);
                        int length = int.Parse(tokens[2]);
                        string substring = password.Substring(index, length);
                        password = password.Remove(index, substring.Length);
                        break;
                    case "Substitute":
                        substring = tokens[1];
                        string substitute = tokens[2];

                        if (!password.Contains(substring))
                        {
                            Console.WriteLine("Nothing to replace!");
                            continue;
                        }
                        password = password.Replace(substring, substitute);
                        break;
                }

                Console.WriteLine(password);
            }

            Console.WriteLine($"Your password is: {password}");
        }
    }
}
