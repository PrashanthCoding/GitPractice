using System;
using System.Text.RegularExpressions;
using System.Linq;

namespace exercises
{
    class Program
    {
        // Main method - entry point of the program
        static void Main(string[] args)
        {
            // Initialize a string variable with some text content
            string text = "CPP Exercises.";

            // Display the original string
            Console.WriteLine("Original string: " + text);

            // Calculate and display the average word length in the string
            Console.WriteLine("The average word length in the said string: " + test(text));

            // Update the string variable with a different text content
            text = "C# syntax is highly expressive, yet it is also simple and easy to learn.";

            // Display the updated string
            Console.WriteLine("Original string: " + text);

            // Calculate and display the average word length in the updated string
            Console.WriteLine("The average word length in the said string: " + test(text));

            // Update the string variable with another text content
            text = "C# is an elegant and type-safe object-oriented language";

            // Display the updated string
            Console.WriteLine("Original string: " + text);

            // Calculate and display the average word length in the updated string
            Console.WriteLine("The average word length in the said string: " + test(text));
        }

        // Method to calculate the average word length in a string
        public static double test(string text)
        {
            // Remove non-alphabetic characters and keep spaces to isolate words
            string new_text = Regex.Replace(text, "[^A-Za-z ]", "");

            // Split the string into words, calculate the length of each word, find the average length of all words
            double average_len = new_text.Split(' ').Select(x => x.Length).Average();

            // Round the average word length to 2 decimal places and return the result
            return Math.Round(average_len, 2);
        }
    }
}
