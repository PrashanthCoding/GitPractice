using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Enter a number: ");
        int number = int.Parse(Console.ReadLine());

        for (int i = 0; i <= 10; i++)
        {
            Console.WriteLine(number + " x " + i + " = " + (number * i));
        }

    }
}