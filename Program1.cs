using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());
        int sum = 0, temp = number, digits = number.ToString().Length;

        while (temp != 0)
        {
            int remainder = temp % 10;
            sum += (int)Math.Pow(remainder, digits);
            temp /= 10;
        }

        if (sum == number)
            Console.WriteLine($"{number} is an Armstrong number.");
        else
            Console.WriteLine($"{number} is not an Armstrong number.");
    }
}
