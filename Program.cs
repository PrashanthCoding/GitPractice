using System;

class PairsWithSum
{
    static void Main()
    {
        int[] arr = { 1, 5, 7, -1, 5 };
        int sum = 6;

        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = i + 1; j < arr.Length; j++)
            {
                if (arr[i] + arr[j] == sum)
                {
                    Console.WriteLine($"Pair: ({arr[i]}, {arr[j]})");
                }
            }
        }
    }
}
