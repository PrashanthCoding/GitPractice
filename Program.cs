using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<string> names = new List<string> { "Alice", "Bob", "Charlie" };

        names.Add("David");

        foreach (var name in names)
            Console.WriteLine(name);
    }
}
