/*
 * C# Program to Implement Sequential Sort
 */
using System;
using System.Collections.Generic;
public static class BubbleSortMethods
{
    public static void BubbleSort<T>(this List<T> list) where T : IComparable
    {
        bool changes;
        int count = list.Count;
        do
        {
            changes = false;
            count--;
            for (int i = 0; i < count; i++)
            {
                if (list[i].CompareTo(list[i + 1]) > 0)
                {
                    T temp = list[i + 1];
                    list[i + 1] = list[i];
                    list[i] = temp;
                    changes = true;
                }
            }
        } while (changes);
    }
}