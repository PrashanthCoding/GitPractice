using System;

class Employee
{
    private int _employeeId;
    private string _name;
    private decimal _hourlyRate;

    public Employee(int id, string name, decimal hourlyRate)
    {
        _employeeId = id;
        _name = name;
        _hourlyRate = hourlyRate;
    }

    public string Name
    {
        get { return _name; }
    }

    public decimal CalculateSalary(int hoursWorked)
    {
        return CalculatePay(hoursWorked);
    }

    private decimal CalculatePay(int hours)
    {
        return _hourlyRate * hours;
    }
}

class Program
{
    static void Main()
    {
        Employee emp = new Employee(101, "John Doe", 25.50m);
        Console.WriteLine($"{emp.Name} Salary: {emp.CalculateSalary(40)}");
    }
}
