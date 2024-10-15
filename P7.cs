using System;

class Program
{
    static void Main()
    {

        // Enter First Number
        Console.Write("Enter first number: ");
        int a = Convert.ToInt32(Console.ReadLine());


        // Enter Second Number
        Console.Write("Enter second number: ");
        int b = Convert.ToInt32(Console.ReadLine());

        int largest = a > b ? a : b;
        Console.WriteLine("Largest number is: " + largest);
    }
}
