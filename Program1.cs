using System;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.Write("Enter a string: ");
        string str = Console.ReadLine();
        string reverseStr = new string(str.Reverse().ToArray());

        if (str == reverseStr)
        {
            Console.WriteLine($"{str} is a palindrome.");
        }
        else
        {
            Console.WriteLine($"{str} is not a palindrome.");
        }
    }
}
