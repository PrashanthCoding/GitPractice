using System;
class HelloWorld
{
    static void Main()
    {
        Console.WriteLine("Enter a Number 1: ");
        int a = Console.ReadLine();
        Console.WriteLine("Enter a Number 2: ");
        int b = Console.ReadLine();
        int result = a + b;
        int result1 = a - b;
        int result2 = a * b;
        int result3 = a / b;
        Console.WriteLine($"Result is : {result}");
        Console.WriteLine($"Result1 is : {result1}");
        Console.WriteLine($"Result2 is : {result2}");
        Console.WriteLine($"Result3 is : {result3}");
        Console.ReadLine();
    }
}
