using System;

class MergeSortedArrays
{
    static void Main()
    {
        int[] arr1 = { 1, 3, 5, 7 };
        int[] arr2 = { 2, 4, 6, 8 };
        int[] merged = new int[arr1.Length + arr2.Length];

        int i = 0, j = 0, k = 0;

        while (i < arr1.Length && j < arr2.Length)
        {
            merged[k++] = arr1[i] < arr2[j] ? arr1[i++] : arr2[j++];
        }

        while (i < arr1.Length)
        {
            merged[k++] = arr1[i++];
        }

        while (j < arr2.Length)
        {
            merged[k++] = arr2[j++];
        }

        Console.WriteLine("Merged Array: " + string.Join(", ", merged));
    }
}
