using System;
class Program
{
    static void Main()
    {
        int[] numbers = { 3, 8, 1, 9, 2, 6, 7 };
        int max = numbers[0];

        foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }

        Console.WriteLine("The maximum number is: " + max);
    }
}
