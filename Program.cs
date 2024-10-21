using System;

class Weather
{
    static void Main()
    {
        Console.WriteLine("Enter the weather (sunny, rainy, cloudy, windy): ");
        string weather = Console.ReadLine().ToLower();

        switch (weather)
        {
            case "sunny":
                Console.WriteLine("It's a bright day.");
                break;
            case "rainy":
                Console.WriteLine("Don't forget your umbrella.");
                break;
            case "cloudy":
                Console.WriteLine("It might rain today.");
                break;
            case "windy":
                Console.WriteLine("Hold onto your hat!");
                break;
            default:
                Console.WriteLine("Unknown weather type!");
                break;
        }
    }
}
