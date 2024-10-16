/*
 * C# Program to Divide Sequence into Groups using LINQ
 */
using System;
using System.Linq;
class Program
{
    static void Main(string[] args)
    {
        var seq = Enumerable.Range(100, 100).Select(x => x / 10f);
        var grps = from x in seq.Select((i, j) => new { i, Grp = j / 10 })
                   group x.i by x.Grp into y
                   select new { Min = y.Min(), Max = y.Max() };
        foreach (var grp in grps)
            Console.WriteLine("Min: " + grp.Min + " Max:" + grp.Max);
        Console.ReadLine();
    }
}