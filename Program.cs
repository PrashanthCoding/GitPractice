/*
 *  C# Program to Illustrate Single Inheritance
 */
using System;
namespace Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            Teacher d = new Teacher();
            d.Teach();
            Student s = new Student();
            s.Learn();
            s.Teach();
            Console.ReadKey();
        }
        class Teacher
        {
            public void Teach()
            {
                Console.WriteLine("Teach");
            }
        }
        class Student : Teacher
        {
            public void Learn()
            {
                Console.WriteLine("Learn");
            }
        }
    }
}