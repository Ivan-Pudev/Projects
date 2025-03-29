using System;
using System.Text.RegularExpressions;

class RegexProject
{
    public static string ExtractDates(string text, string oldWord, string newWord)
    {
        /**
         * This function should replace all occurrences of 'oldWord' with 'newWord' in the given text.
         * Use Regex.Replace() with a regex pattern.
         */
        // Write your regex pattern here
        string oldWordPattern = @"";
        //text = Regex.Replace(text,)
        // Return the modified text
        return text; // Change this to return actual results
    }
    public static string FindURLs(string text)
    {
        string urlPatterns = @"https:\/\/[A-Za-z]+\.[a-z]+";

        MatchCollection foundUrls = Regex.Matches(text, urlPatterns);
        return text;
    }
    public static string ReplaceWord(string text, string oldWord, string newWord)
    {
        string replaceWord = @"\b" + Regex.Escape(oldWord) + @"\b";
       
        string result = Regex.Replace(text, replaceWord, newWord, RegexOptions.IgnoreCase);
        return result;
    }


    static void Main()
    {
        string text = "I love C#! C# is amazing!";
        Console.WriteLine(ReplaceWord(text, "C#", "F#"));
        // Expected Output: "I love F#! F# is amazing!"
        string textDates = "DD/MM/YYYY or MM-DD-YYYY.";
        Console.WriteLine(ReplaceWord(text, "C#", "F#"));
        // Expected Output: "I love F#! F# is amazing!"
    }
}