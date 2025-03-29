using System;
using System.Text.RegularExpressions;

class RegexProject
{
    public static string FindEmail(string text)
    {
        string emailPattern = @"[A-Za-z]+([0-9]+)?\@[A-Za-z]+\.[A-Za-z]+";

        Match email = Regex.Match(text, emailPattern);
        if (email.Success)
        {
            return email.Groups[0].Value;
        }
        return null; 
    }

    static void Main()
    {
        string text = "Hello! My email is student123@gmail.com and my phone number is +359 888-123-456.";
        Console.WriteLine(FindEmail(text)); 
    }
}
