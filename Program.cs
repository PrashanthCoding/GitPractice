/*
 * C# Program to Demonstrate the Difference between 
 * Value Type Parameter and Reference Type Parameter
 */
using System;
namespace Example1
{
    class Program
    {
        public static void value(int num)
        {
            num++;
        }
        public static void reference(ref int num)
        {
            num++;
        }

        static void Main(string[] args)
        {
            int num;
            Console.Write("Enter a Number:\t");
            num = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\n\tValue Type:");
            Console.Write("\nPrevious Value:\t{0}", num);
            Program.value(num);
            Console.Write("\nCurrent Value:\t{0}", num);
            Console.WriteLine("\n\tReference Type");
            Console.Write("\nPrevious Value:\t{0}", num);
            Program.reference(ref num);
            Console.Write("\nCurrent Value:\t{0}", num);
            Console.ReadLine();
        }
    }
}