using System;

class Address
{
    public string City { get; set; }
}

class University
{
    public Address UniversityAddress { get; set; }
    public University() { UniversityAddress = new Address(); }
}

class Program
{
    static void Main()
    {
        University uni = new University();
        uni.UniversityAddress.City = "Australia";
        Console.WriteLine($"University located in {uni.UniversityAddress.City}");
    }
}
