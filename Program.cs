using System;

class MissingNumber
{
    static void Main()
    {
        int[] arr = { 1, 2, 4, 5, 6 };
        int n = arr.Length + 1;
        int totalSum = (n * (n + 1)) / 2;
        int arrSum = 0;

        foreach (int num in arr)
        {
            arrSum += num;
        }

        int missingNumber = totalSum - arrSum;
        Console.WriteLine("Missing Number: " + missingNumber);
    }
}
