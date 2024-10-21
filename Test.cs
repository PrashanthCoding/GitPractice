using System;

class TrafficSignal
{
    static void Main()
    {
        Console.Write("Enter the traffic light color (red, yellow, green): ");
        string light = Console.ReadLine().ToLower();

        switch (light)
        {
            case "red":
                Console.WriteLine("Stop");
                break;
            case "yellow":
                Console.WriteLine("Get Ready");
                break;
            case "green":
                Console.WriteLine("Go");
                break;
            default:
                Console.WriteLine("Invalid color!");
                break;
        }
    }
}
