using System;

class Calculator
{
    public int Add(int a, int b)
    {
        return Calculate(a, b, '+');
    }

    public int Subtract(int a, int b)
    {
        return Calculate(a, b, '-');
    }

    private int Calculate(int a, int b, char operation)
    {
        return operation switch
        {
            '+' => a + b,
            '-' => a - b,
            _ => 0
        };
    }
}

class Program
{
    static void Main()
    {
        Calculator calc = new Calculator();
        Console.WriteLine(calc.Add(10, 5));  // Output: 15
        Console.WriteLine(calc.Subtract(10, 5));  // Output: 5
    }
}
