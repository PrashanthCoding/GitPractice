using System;

class VehicleType
{
    static void Main()
    {
        Console.WriteLine("Enter a vehicle type (car, bike, truck): ");
        string vehicle = Console.ReadLine().ToLower();

        switch (vehicle)
        {
            case "car": Console.WriteLine("You chose a car."); break;
            case "bike": Console.WriteLine("You chose a bike."); break;
            case "truck": Console.WriteLine("You chose a truck."); break;
            default: Console.WriteLine("Invalid vehicle type!"); break;
        }
    }
}
