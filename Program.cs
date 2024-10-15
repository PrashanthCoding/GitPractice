using System;

class Program
{
    static void Main()
    {
        int a, b, temp;

        Console.Write("Enter the first number: ");
        a = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter the second number: ");
        b = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine($"Before Swap: a = {a}, b = {b}");

        // Swapping logic using temporary variable
        temp = a;
        a = b;
        b = temp;

        Console.WriteLine($"After Swap: a = {a}, b = {b}");
    }
}
