using System;
delegate void dele(string s);
class TestClass
{
    static void Good(string s)
    {
        System.Console.WriteLine("  Good, {0}!", s);
    }

    static void Morning(string s)
    {
        System.Console.WriteLine("  Morning, {0}!", s);
    }

    static void Main()
    {
        dele firstdel, secondDel, multiDel, multiMinusfirstdel;
        firstdel = Good;
        secondDel = Morning;
        multiDel = firstdel + secondDel;
        multiMinusfirstdel = multiDel - firstdel;
        Console.WriteLine("Invoking delegate firstdel:");
        firstdel("A");
        Console.WriteLine("Invoking delegate secondDel:");
        secondDel("B");
        Console.WriteLine("Invoking delegate multiDel:");
        multiDel("C");
        Console.WriteLine("Invoking delegate multiMinusfirstdel:");
        multiMinusfirstdel("D");
        Console.ReadLine();
    }
}