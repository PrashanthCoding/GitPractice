using System;

class BinarySearch
{
    static void Main()
    {
        int[] arr = { 1, 2, 3, 4, 5, 6, 7 };
        int target = 4;
        int left = 0, right = arr.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (arr[mid] == target)
            {
                Console.WriteLine($"Found {target} at index {mid}");
                return;
            }
            if (arr[mid] < target) left = mid + 1;
            else right = mid - 1;
        }

        Console.WriteLine($"{target} not found in the array");
    }
}
