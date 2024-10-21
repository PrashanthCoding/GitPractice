using System;

class GradingSystem
{
    static void Main()
    {
        Console.Write("Enter marks (0-100): ");
        int marks = int.Parse(Console.ReadLine());

        switch (marks / 10)
        {
            case 9:
            case 10: Console.WriteLine("Grade: A"); break;
            case 8: Console.WriteLine("Grade: B"); break;
            case 7: Console.WriteLine("Grade: C"); break;
            case 6: Console.WriteLine("Grade: D"); break;
            default: Console.WriteLine("Grade: F"); break;
        }
    }
}
