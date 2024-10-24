using System;

class Program
{
    static void Main()
    {
        int number = 10;

        // if-else statement
        if (number > 0)
            Console.WriteLine("Positive number");
        else
            Console.WriteLine("Negative number");

        // switch statement
        switch (number)
        {
            case 10:
                Console.WriteLine("Number is 10");
                break;
            default:
                Console.WriteLine("Number is not 10");
                break;
        }

        // for loop
        for (int i = 1; i <= 5; i++)
            Console.WriteLine(i);
    }
}
