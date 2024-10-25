using System;

class Complex
{
    public int Real { get; set; }
    public int Imaginary { get; set; }

    public Complex(int real, int imaginary)
    {
        Real = real;
        Imaginary = imaginary;
    }

    public static Complex operator +(Complex c1, Complex c2)
    {
        return new Complex(c1.Real + c2.Real, c1.Imaginary + c2.Imaginary);
    }

    public void Display()
    {
        Console.WriteLine($"{Real} + {Imaginary}i");
    }
}

class Program
{
    static void Main()
    {
        Complex c1 = new Complex(3, 2);
        Complex c2 = new Complex(1, 7);
        Complex sum = c1 + c2;

        sum.Display();
    }
}
