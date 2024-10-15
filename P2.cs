using System;

class Program
{
    static void Main()
    {
        int num1, num2, sum;

        Console.Write("Enter first number: ");
        num1 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter second number: ");
        num2 = Convert.ToInt32(Console.ReadLine());

        sum = num1 + num2;
        Console.WriteLine("Sum: " + sum);
    }
}
