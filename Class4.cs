using System;

class Shape
{
    public void DisplayShape() => Console.WriteLine("This is a shape.");
}

class Rectangle : Shape
{
    public void DrawRectangle() => Console.WriteLine("Drawing Rectangle...");
}

class Circle : Shape
{
    public void DrawCircle() => Console.WriteLine("Drawing Circle...");
}

class Program
{
    static void Main()
    {
        Rectangle rect = new Rectangle();
        Circle circle = new Circle();
        rect.DisplayShape();
        rect.DrawRectangle();
        circle.DisplayShape();
        circle.DrawCircle();
    }
}
