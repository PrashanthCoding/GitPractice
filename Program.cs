using System;
class Factorial
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());
        int fact = 1;

        for (int i = 1; i <= number; i++)
        {
            fact *= i;
        }

        Console.WriteLine("Factorial of " + number + " is: " + fact);
    }
}
