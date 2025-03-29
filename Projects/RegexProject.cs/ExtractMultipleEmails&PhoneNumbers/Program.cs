using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class RegexProject
{
    public static Dictionary<string, List<string>> ExtractEmailsAndPhones(string text)
    {
        Dictionary<string, List<string>> emailsPhones = new();
        string emailPattern = @"[A-Za-z]+([0-9]+)?\@[A-Za-z]+\.[A-Za-z]+";
        string phonePattern = @"\+\d+([\-\ ])\d+\1\d+\1\d+";

        MatchCollection emails = Regex.Matches(text, emailPattern);
        List<string> foundEmails = emails.Select(m => m.Value).ToList();

        MatchCollection phones = Regex.Matches(text, phonePattern);
        List<string> foundPhones = phones.Select(m => m.Value).ToList();

        emailsPhones.Add("emails", foundEmails);
        emailsPhones.Add("phones", foundPhones);

        return emailsPhones;
    }

    static void Main()
    {
        string text = @"
            Contact us at support@company.com or sales@business.net.
            For urgent inquiries, call +1-555-678-9999 or +44 123 4567 890.
        ";
        var result = ExtractEmailsAndPhones(text);
        Console.WriteLine($"{{ emails: ['{string.Join("', '", result["emails"])}'], phones: ['{string.Join("', '", result["phones"])}'] }}");

    }
}