using System;
using System.Text.RegularExpressions;

namespace exercises
{
    class Program
    {
        // Main method - entry point of the program
        static void Main(string[] args)
        {
            // Initialize a string variable with a password-like content
            string text = "Suuu$21g@";

            // Display the original string
            Console.WriteLine("Original string: " + text);

            // Check if the string is a valid password
            Console.WriteLine("Check the said string is a valid password? " + test(text));

            // Update the string variable with a different content
            text = "W#1g@";

            // Display the updated string
            Console.WriteLine("\nOriginal string: " + text);

            // Check if the updated string is a valid password
            Console.WriteLine("Check the said string is a valid password? " + test(text));

            // Update the string variable with another content
            text = "a&&g@";

            // Display the updated string
            Console.WriteLine("\nOriginal string: " + text);

            // Check if the updated string is a valid password
            Console.WriteLine("Check the said string is a valid password? " + test(text));

            // Update the string variable with more content
            text = "sdsd723#$Amid";

            // Display the updated string
            Console.WriteLine("\nOriginal string: " + text);

            // Check if the updated string is a valid password
            Console.WriteLine("Check the said string is a valid password? " + test(text));

            // Update the string variable with even more content
            text = "sdsd723#$Amidkiouy";

            // Display the updated string
            Console.WriteLine("\nOriginal string: " + text);

            // Check if the updated string is a valid password
            Console.WriteLine("Check the said string is a valid password? " + test(text));
        }

        // Method to check if a string is a valid password
        public static bool test(string text)
        {
            // Check if the length of the string is between 7 and 16 characters
            // Check if the string contains at least one uppercase letter, one lowercase letter, one digit, and one special character
            // Ensure that the string doesn't contain any character that doesn't belong to the allowed set
            bool result = text.Length >= 7 && text.Length <= 16
&& Regex.IsMatch(text, "[A-Z]")
&& Regex.IsMatch(text, "[a-z]")
&& Regex.IsMatch(text, @"\d")
&& Regex.IsMatch(text, @"[!-/:-@\[-_{-~]")
&& !Regex.IsMatch(text, @"[^\dA-Za-z!-/:-@\[-_{-~]");

            // Return the result indicating whether the string is a valid password
            return result;
        }
    }
}
