using System;
using System.Collections.Generic;

class CommonElements
{
    static void Main()
    {
        int[] array1 = { 1, 2, 3, 4, 5 };
        int[] array2 = { 4, 5, 6, 7, 8 };
        List<int> common = new List<int>();

        foreach (int num in array1)
        {
            if (Array.Exists(array2, element => element == num))
            {
                common.Add(num);
            }
        }

        Console.WriteLine("Common Elements: " + string.Join(", ", common));
    }
}
