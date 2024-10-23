using System;

int[] arr = { 5, 2, 9, 1, 5, 6 };
int max = arr[0];

for (int i = 1; i < arr.Length; i++)
{
    if (arr[i] > max)
    {
        max = arr[i];
    }
}

Console.WriteLine("Maximum element is: " + max);
