using System;

namespace SwitchCaseExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Simple Calculator using Switch Case");
            Console.WriteLine("Enter the first number: ");
            double num1 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter the second number: ");
            double num2 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Choose an operation: ");
            Console.WriteLine("1: Addition (+)");
            Console.WriteLine("2: Subtraction (-)");
            Console.WriteLine("3: Multiplication (*)");
            Console.WriteLine("4: Division (/)");

            Console.Write("Enter your choice (1-4): ");
            int choice = Convert.ToInt32(Console.ReadLine());

            double result = 0;
            bool validOperation = true;

            switch (choice)
            {
                case 1:
                    result = num1 + num2;
                    Console.WriteLine("Result: " + num1 + " + " + num2 + " = " + result);
                    break;
                case 2:
                    result = num1 - num2;
                    Console.WriteLine("Result: " + num1 + " - " + num2 + " = " + result);
                    break;
                case 3:
                    result = num1 * num2;
                    Console.WriteLine("Result: " + num1 + " * " + num2 + " = " + result);
                    break;
                case 4:
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                        Console.WriteLine("Result: " + num1 + " / " + num2 + " = " + result);
                    }
                    else
                    {
                        Console.WriteLine("Division by zero is not allowed.");
                        validOperation = false;
                    }
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select between 1 and 4.");
                    validOperation = false;
                    break;
            }

            if (validOperation)
            {
                Console.WriteLine("Calculation successful!");
            }
        }
    }
}
