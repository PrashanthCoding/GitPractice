/*
 * C# Program to Illustrate AutoIncrement Operator using ++
 */
using System;
class Program
{
    static void Main()
    {
        int i = 0;
        Console.WriteLine(i);
        i++;
        Console.WriteLine(i);
        i += 3;
        Console.WriteLine(i);
        ++i;
        Console.WriteLine(i);
        i += i;
        Console.WriteLine(i);
        Console.ReadLine();
    }
}