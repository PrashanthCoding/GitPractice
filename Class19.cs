/*
 * C# Program to Demonstrate StringReader
 */
using System;
using System.IO;

class Program
{
    const string text = @"Sanfoundry
offers Training and Competency 
development programs";
    static void Main()
    {
        using (StringReader reader = new StringReader(text))
        {
            int count = 0;
            string textline;
            while ((textline = reader.ReadLine()) != null)
            {
                count++;
                Console.WriteLine("Line {0}: {1}", count, textline);
            }
            Console.ReadLine();
        }
    }
}