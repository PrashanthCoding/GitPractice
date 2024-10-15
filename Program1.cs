using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] numbers = { 1, 2, 3, 4, 5, 1, 2, 6, 7, 8, 9, 3 };

        var duplicates = numbers.GroupBy(n => n)
                                .Where(g => g.Count() > 1)
                                .Select(g => g.Key);

        Console.WriteLine("Duplicate numbers: " + string.Join(", ", duplicates));
    }
}
