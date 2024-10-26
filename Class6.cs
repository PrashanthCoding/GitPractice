using System;

abstract class Employee
{
    public abstract void CalculateSalary();
}

class Developer : Employee
{
    public override void CalculateSalary() => Console.WriteLine("Salary calculated for Developer.");
}

class Program
{
    static void Main()
    {
        Employee emp = new Developer();
        emp.CalculateSalary();
    }
}
