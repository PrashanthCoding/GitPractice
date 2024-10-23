using System;

int[] arr = { 2, 4, 6, 8, 10 };
int sum = 0;

for (int i = 0; i < arr.Length; i++)
{
    sum += arr[i];
}

double average = (double)sum / arr.Length;
Console.WriteLine("Average of elements is: " + average);
