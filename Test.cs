using System;

class ArithmeticOperations
{
    static void Main()
    {
        Console.WriteLine("Enter two numbers:");
        int num1 = int.Parse(Console.ReadLine());
        int num2 = int.Parse(Console.ReadLine());

        Console.WriteLine("Choose an operation (+, -, *, /, %):");
        char operation = Convert.ToChar(Console.ReadLine());

        switch (operation)
        {
            case '+': Console.WriteLine($"Sum: {num1 + num2}"); break;
            case '-': Console.WriteLine($"Difference: {num1 - num2}"); break;
            case '*': Console.WriteLine($"Product: {num1 * num2}"); break;
            case '/': Console.WriteLine($"Quotient: {num1 / num2}"); break;
            case '%': Console.WriteLine($"Remainder: {num1 % num2}"); break;
            default: Console.WriteLine("Invalid operation!"); break;
        }
    }
}
