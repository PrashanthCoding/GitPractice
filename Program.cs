using System;

int[] arr = { 10, 2, 3, 5, 1 };
Array.Sort(arr);
Array.Reverse(arr);

Console.WriteLine("Sorted in descending: " + string.Join(", ", arr));
