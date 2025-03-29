using System;
using System.Text.RegularExpressions;

class RegexProject
{
    public static bool ValidateEmail(string email)
    {
        string validateEmail = @"[A-Za-z]+\@[A-Za-z]+\.[A-Za-z]+";

        bool isEmailValid = Regex.IsMatch(email, validateEmail);

        if(isEmailValid)
        {
            return true;
        }
        return false; 
    }

    public static bool ValidatePassword(string password)
    {
        string validatePassword = @"(?=(?:.*[A-Z]){1,})(?=(?:.*[a-z]){1,})(?=(?:.*\d){1,})(?=(?:.*[@\$!\%\*\?\&]){1,})[A-Za-z\d@\$!\%\*\?\&]{8,}";

        bool isPasswordValid = Regex.IsMatch(password, validatePassword);

        if (isPasswordValid)
        {
            return true;
        }
        return false; 
    }

    static void Main()
    {
        Console.WriteLine(ValidateEmail("user@domain.com"));  // Expected Output: true  
        Console.WriteLine(ValidateEmail("invalid-email"));    // Expected Output: false  

        Console.WriteLine(ValidatePassword("Secure123!"));    // Expected Output: true  
        Console.WriteLine(ValidatePassword("weakpass"));      // Expected Output: false  
    }
}