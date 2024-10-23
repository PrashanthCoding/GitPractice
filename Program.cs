using System;
using System.Collections.Generic;
using System.Linq;

int[] arr = { 1, 2, 4, 5 };
List<int> list = arr.ToList();
list.Insert(2, 3); // Insert 3 at index 2

Console.WriteLine("Array after insertion: " + string.Join(", ", list));
