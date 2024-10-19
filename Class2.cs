using System;
using System.Linq;
class Palindrome
{
    static void Main()
    {
        Console.Write("Enter a string: ");
        string str = Console.ReadLine();
        string reversedStr = new string(str.Reverse().ToArray());

        if (str.Equals(reversedStr, StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine(str + " is a palindrome.");
        }
        else
        {
            Console.WriteLine(str + " is not a palindrome.");
        }
    }
}
