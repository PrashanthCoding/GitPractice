using System;

class TemperatureConversion
{
    static void Main()
    {
        Console.WriteLine("Choose conversion (C to F, F to C): ");
        string conversion = Console.ReadLine().ToLower();

        Console.Write("Enter temperature: ");
        double temp = double.Parse(Console.ReadLine());

        switch (conversion)
        {
            case "c to f":
                Console.WriteLine($"Temperature in Fahrenheit: {temp * 9 / 5 + 32}");
                break;

            case "f to c":
                Console.WriteLine($"Temperature in Celsius: {(temp - 32) * 5 / 9}");
                break;

            default:
                Console.WriteLine("Unknown conversion!");
                break;
        }
    }
}
