using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter the base number: ");
        int baseNum = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter the exponent: ");
        int exponent = Convert.ToInt32(Console.ReadLine());

        int result = 1;
        for (int i = 1; i <= exponent; i++)
        {
            result *= baseNum;
        }

        Console.WriteLine($"{baseNum} to the power of {exponent} is: " + result);
    }
}
