using System;
using System.Collections.Generic;

// 1
var number = 10;
Console.WriteLine(number);

// 2
var firstname = "Prashanth";
var lastname = "Murugasamy";
Console.WriteLine(firstname + " " + lastname);

// 3
var numbers = new int[] { 1, 2, 3, 4, 5 };
Console.WriteLine(string.Join(", ", number));

// 4
var numberList = new List<int> { 1, 2, 3, 4, 5 };
numberList.ForEach(n => Console.WriteLine(n));


// 5
var dictionary = new Dictionary<string, int> { { "One", 1 }, { "Two", 2 }, { "Three", 3 } };
foreach (var item in dictionary)
{
    Console.WriteLine($"{item.Key}: " { item.Value});
}


// 6
var items = new List<string> { "Apple", "Banana", "Orange" };
foreach (var item in items)
{
    Console.WriteLine(item);
}


// 7
var person = new { Name = "Prashanth", Age = 30 };
Console.WriteLine($"{person.Name} is {person.Age} years old.");


// 8
var numbers = new int[] { 1, 2, 3, 4, 5 };
var evenNumbers = from n in numbers where n % 2 == 0 select n;
evenNumbers.ToList().ForEach(Console.WriteLine());


// 9
var product = new { Id = 101, Name = "Laptop", Price = 899.99 };
Console.Write($"{product.Name}: ${product.Price}");


// 10
var today = DateTime.Now;
Console.WriteLine(today);


// 11
var salary = 30000.50;
Console.WriteLine($"Salary : {salary}");


// 12
var age = (int?)null;
Console.WriteLine(age ?? "No age specified");


// 13
var people = new List<object>
{
    new {Name = "Prashanth", Age = 28, Salary = 30000},
    new {Name = "Manoj", Age = 32, Salary = 50000}
};

people.ForEach(p => Console.WriteLine(p));


// 14
var name = "C# Programming";
var level = "Intermediate";
Console.WriteLine($"Course: {name}, Level: {level}");


// 15
var square = new Func<int, int>(x => x * x);
Console.WriteLine(square(5);


// 16
var item = new KeyValuePair<string, int>("Apple", 50);
Console.WriteLine($"{item.Key}: {item.Value}");


// 17
var tuple = (Id: 1, Name: "Book", Price: 10.99);
Console.WriteLine(tuple);


// 18
var numbers = new[] { 1, 2, 3, 4, 5 };
var evenNumbers = number.Where(n => n % 2 == 0);


// 19
var matrix = new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } };
Console.WriteLine(matrix[1, 1]);


// 20
var names = new string[] { "Prashanth", "Manoj", "Arjun" };




