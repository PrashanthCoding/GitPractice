using System;
class Fibonacci
{
    static void Main()
    {
        int n1 = 0, n2 = 1, n3, number;
        Console.Write("Enter the number of elements: ");
        number = int.Parse(Console.ReadLine());
        Console.Write(n1 + " " + n2); // Print 0 and 1
        
        for (int i = 2; i < number; ++i)
        {
            n3 = n1 + n2;
            Console.Write(" " + n3);
            n1 = n2;
            n2 = n3;
        }
    }
}
