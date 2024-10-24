using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6 };
        Predicate<int> isEven = x => x % 2 == 0;

        List<int> evenNumbers = numbers.FindAll(isEven);

        Console.WriteLine("Even numbers: ");
        evenNumbers.ForEach(Console.WriteLine);
    }
}
