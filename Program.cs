﻿using System;

int[] arr = { 1, 2, 3, 4, 5 };
int max = arr[0];

for (int i = 1; i < arr.Length; i++)
{
    if (arr[i] > max)
    {
        max = arr[i];
    }
}

Console.WriteLine("Maximum element is : " + max);