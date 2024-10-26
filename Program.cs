using System;

class Vehicle
{
    public string Brand { get; set; }
    public Vehicle(string brand)
    {
        Brand = brand;
    }

    public void DisplayBrand()
    {
        Console.WriteLine($"Vehicle Brand: {Brand}");
    }
}

class Car : Vehicle
{
    public int Speed { get; set; }
    public Car(string brand, int speed) : base(brand)
    {
        Speed = speed;
    }

    public void DisplaySpeed()
    {
        Console.WriteLine($"{Brand} car speed: {Speed} km/h");
    }
}

class ElectricCar : Car
{
    public int BatteryCapacity { get; set; }
    public ElectricCar(string brand, int speed, int batteryCapacity) : base(brand, speed)
    {
        BatteryCapacity = batteryCapacity;
    }

    public void DisplayBattery()
    {
        Console.WriteLine($"{Brand} has a battery capacity of {BatteryCapacity} kWh.");
    }
}

class Program
{
    static void Main()
    {
        ElectricCar myTesla = new ElectricCar("Tesla", 200, 100);
        myTesla.DisplayBrand();
        myTesla.DisplaySpeed();
        myTesla.DisplayBattery();
    }
}
