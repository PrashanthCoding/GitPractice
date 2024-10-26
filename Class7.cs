using System;

class Person
{
    public string Name { get; set; }
    public Person(string name) { Name = name; }
}

class Employee : Person
{
    public int EmployeeId { get; set; }
    public Employee(string name, int id) : base(name) { EmployeeId = id; }
}

class Program
{
    static void Main()
    {
        Employee emp = new Employee("Prashanth", 1234);
        Console.WriteLine($"Employee: {emp.Name}, ID: {emp.EmployeeId}");
    }
}
