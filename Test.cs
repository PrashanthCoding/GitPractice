using System;
using System.Linq;

int[] arr = { 1, 2, 3, 4, 5 };
int n = 2; // Rotate by 2 positions
int[] rotatedArr = arr.Skip(n).Concat(arr.Take(n)).ToArray();

Console.WriteLine("Array after left rotation: " + string.Join(", ", rotatedArr));
