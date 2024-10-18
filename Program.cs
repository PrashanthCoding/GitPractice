using System;

class Program
{
    static void Main()
    {
        int num1 = 0, num2 = 1, num3, i, n;

        Console.Write("Enter the number of elements: ");
        n = Convert.ToInt32(Console.ReadLine());

        Console.Write($"{num1} {num2} "); // printing first two elements

        for (i = 2; i < n; ++i) // loop starts from 2
        {
            num3 = num1 + num2;
            Console.Write(num3 + " ");
            num1 = num2;
            num2 = num3;
        }
    }
}
