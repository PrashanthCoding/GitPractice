using System;
using System.Text.RegularExpressions;

namespace exercises
{
    class Program
    {
        // Main method - entry point of the program
        static void Main(string[] args)
        {
            // Initialize a string variable with a hexadecimal color code
            string hc = "#CD5C5C";

            // Display the hexadecimal code
            Console.WriteLine("Hex Code: " + hc);

            // Check if the string is a valid hex code and display the result
            Console.WriteLine("Check the said string is valid hex code or not: " + test(hc));

            // Update the string variable with a new hexadecimal color code
            hc = "#f08080";

            // Display the new hexadecimal code
            Console.WriteLine("\nHex Code: " + hc);

            // Check if the new string is a valid hex code and display the result
            Console.WriteLine("Check the said string is valid hex code or not: " + test(hc));

            // Update the string variable with another hexadecimal color code
            hc = "#E9967A";

            // Display the new hexadecimal code
            Console.WriteLine("\nHex Code: " + hc);

            // Check if the new string is a valid hex code and display the result
            Console.WriteLine("Check the said string is valid hex code or not: " + test(hc));

            // Update the string variable with another hexadecimal color code (with a mistake)
            hc = "#EFFA07A";

            // Display the new hexadecimal code
            Console.WriteLine("\nHex Code: " + hc);

            // Check if the new string is a valid hex code and display the result
            Console.WriteLine("Check the said string is valid hex code or not: " + test(hc));
        }

        // Method to test if a string represents a valid hexadecimal color code
        public static bool test(string hc)
        {
            // Use Regex to check if the string matches the pattern for a valid hex code
            return Regex.IsMatch(hc, @"[#][0-9A-Fa-f]{6}\b");
        }
    }
}
