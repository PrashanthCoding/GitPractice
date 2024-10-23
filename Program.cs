using System;
using System.Linq;

int[] arr = { 2, 3, 5, 7, 8 };
var oddNumbers = arr.Where(x => x % 2 != 0).ToArray();

Console.WriteLine("Odd numbers: " + string.Join(", ", oddNumbers));
