/*
 * C# Program to Demonstrate Prefix Operator
 */
using System;
namespace Program
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int Input = 100;
            Input = ++Input;
            Console.WriteLine("Number After pre Increment : " + Input.ToString());
            Input = --Input;
            Console.WriteLine("Number After pre Decrement : " + Input.ToString());
            Console.ReadLine();
        }
    }
}