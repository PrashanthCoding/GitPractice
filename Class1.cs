using System;

// Define a class for handling specific logic
public class Calculator
{
    // Method to add numbers
    public int Add(int a, int b)
    {
        return a + b;
    }

    // Method to subtract numbers
    public int Subtract(int a, int b)
    {
        return a - b;
    }

    // Method to multiply numbers
    public int Multiply(int a, int b)
    {
        return a * b;
    }

    // Method to divide numbers
    public int Divide(int a, int b)
    {
        if (b == 0)
            throw new DivideByZeroException("Cannot divide by zero.");
        return a / b;
    }
}

// Main Program class to structure logic
public class Program
{
    // Entry point for the program
    public static void Main(string[] args)
    {
        var calc = new Calculator();

        Console.WriteLine("Addition of 5 + 3: " + calc.Add(5, 3));
        Console.WriteLine("Subtraction of 10 - 4: " + calc.Subtract(10, 4));
        Console.WriteLine("Multiplication of 6 * 2: " + calc.Multiply(6, 2));
        Console.WriteLine("Division of 12 / 3: " + calc.Divide(12, 3));
    }
}
