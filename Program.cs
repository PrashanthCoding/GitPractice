using System;

class Counter
{
    public static int Count = 0;

    public Counter()
    {
        Count++;
    }

    public static void DisplayCount()
    {
        Console.WriteLine("Number of instances: " + Count);
    }
}

class Program
{
    static void Main()
    {
        Counter c1 = new Counter();
        Counter c2 = new Counter();
        Counter c3 = new Counter();

        Counter.DisplayCount(); // Displays 3
    }
}
