using System;

class TransposeMatrix
{
    static void Main()
    {
        int[,] matrix = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
        int[,] transpose = new int[matrix.GetLength(1), matrix.GetLength(0)];

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                transpose[j, i] = matrix[i, j];
            }
        }

        for (int i = 0; i < transpose.GetLength(0); i++)
        {
            for (int j = 0; j < transpose.GetLength(1); j++)
            {
                Console.Write(transpose[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
}
