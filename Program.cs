using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter a string:");
        string input = Console.ReadLine();
        
        if (IsPalindrome(input))
        {
            Console.WriteLine($"{input} is a palindrome.");
        }
        else
        {
            Console.WriteLine($"{input} is not a palindrome.");
        }
    }

    static bool IsPalindrome(string str)
    {
        // Convert to lower case and remove spaces for accurate comparison
        str = str.ToLower().Replace(" ", "");

        // Compare the string with its reverse
        int len = str.Length;
        for (int i = 0; i < len / 2; i++)
        {
            if (str[i] != str[len - 1 - i])
            {
                return false;
            }
        }
        return true;
    }
}
