using System;

class Person
{
    private string name;
    private int age;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public int Age
    {
        get { return age; }
        set
        {
            if (value >= 0)
                age = value;
            else
                Console.WriteLine("Age cannot be negative.");
        }
    }
}

class Program
{
    static void Main()
    {
        Person person = new Person();
        person.Name = "John Doe";
        person.Age = 25;
        Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");
    }
}
