using System;

class Program
{
    static void Main()
    {
        int a, b;

        Console.Write("Enter first number: ");
        a = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter second number: ");
        b = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine($"Before Swap: a = {a}, b = {b}");

        // Swapping logic without a temp variable
        a = a + b;
        b = a - b;
        a = a - b;

        Console.WriteLine($"After Swap: a = {a}, b = {b}");
    }
}
