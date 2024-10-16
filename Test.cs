/*
 * C# Program to Demonstrate Pass by Reference Parameter 
 */
using System;
class Program
{
    static void Main(string[] args)
    {
        int val;
        val = 4;
        Console.WriteLine("Value Before : {0}", val);
        square(ref val);
        Console.WriteLine("Value After : {0}", val);
        Console.Read();
    }
    static void square(ref int refParam)
    {
        refParam *= refParam;
    }
}