using System;

class Program
{
    static void Main()
    {
        int[] arr = { 10, 20, 4, 45, 99 };

        int largest = int.MinValue;
        int secondLargest = int.MinValue;

        foreach (int num in arr)
        {
            if (num > largest)
            {
                secondLargest = largest;
                largest = num;
            }
            else if (num > secondLargest && num != largest)
            {
                secondLargest = num;
            }
        }

        Console.WriteLine($"The second largest element is {secondLargest}");
    }
}
