using System;

class LargestOfThree
{
    static void Main()
    {
        Console.Write("Enter first number: ");
        int num1 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter second number: ");
        int num2 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter third number: ");
        int num3 = Convert.ToInt32(Console.ReadLine());

        int largest = num1;

        if (num2 > largest)
            largest = num2;
        if (num3 > largest)
            largest = num3;

        Console.WriteLine($"Largest number is {largest}");
    }
}
