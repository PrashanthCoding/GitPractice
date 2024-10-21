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
        Console.ReadLine($"Result is : {result}");
        Console.ReadLine();
    }
}
