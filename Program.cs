using System;

class Vehicle
{
    public string Brand { get; set; }
}

class Car : Vehicle
{
    public int Speed { get; set; }
}

class ElectricCar : Car
{
    public int BatteryCapacity { get; set; }
}

class Program
{
    static void Main()
    {
        ElectricCar tesla = new ElectricCar { Brand = "Tesla", Speed = 200, BatteryCapacity = 100 };
        Console.WriteLine($"{tesla.Brand}, Speed: {tesla.Speed}, Battery: {tesla.BatteryCapacity} kWh");
    }
}
