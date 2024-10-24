using System;

class Program
{
    static void Main()
    {
        Func<int, int, int> add = (x, y) => x + y;
        Console.WriteLine("Sum: " + add(5, 3));
    }
}
