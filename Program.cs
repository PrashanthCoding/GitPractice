using System;

class MatrixRotation
{
    static void Main()
    {
        int[,] matrix = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
        int n = matrix.GetLength(0);
        int[,] rotated = new int[n, n];

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                rotated[j, n - 1 - i] = matrix[i, j];
            }
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(rotated[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
}
