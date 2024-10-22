using System;

class ShapeAreaCalculator
{
    static void Main()
    {
        Console.WriteLine("Choose a shape (circle, square, rectangle): ");
        string shape = Console.ReadLine().ToLower();

        switch (shape)
        {
            case "circle":
                Console.Write("Enter the radius: ");
                double radius = double.Parse(Console.ReadLine());
                Console.WriteLine($"Area of Circle: {Math.PI * radius * radius}");
                break;

            case "square":
                Console.Write("Enter the side length: ");
                double side = double.Parse(Console.ReadLine());
                Console.WriteLine($"Area of Square: {side * side}");
                break;

            case "rectangle":
                Console.Write("Enter the length: ");
                double length = double.Parse(Console.ReadLine());
                Console.Write("Enter the width: ");
                double width = double.Parse(Console.ReadLine());
                Console.WriteLine($"Area of Rectangle: {length * width}");
                break;

            default:
                Console.WriteLine("Unknown shape!");
                break;
        }
    }
}
