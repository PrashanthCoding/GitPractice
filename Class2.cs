using System;
class PrimeChecker
{
    static void Main()
    {
        int num, i, m = 0, flag = 0;
        Console.Write("Enter a number: ");
        num = int.Parse(Console.ReadLine());
        m = num / 2;
        if (num == 0 || num == 1)
        {
            Console.WriteLine(num + " is not prime.");
        }
        else
        {
            for (i = 2; i <= m; i++)
            {
                if (num % i == 0)
                {
                    Console.WriteLine(num + " is not prime.");
                    flag = 1;
                    break;
                }
            }
            if (flag == 0)
            {
                Console.WriteLine(num + " is a prime number.");
            }
        }
    }
}
