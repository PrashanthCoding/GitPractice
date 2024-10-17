/*
 * C# Program to Perform Matrix Addition 
 */
using System;

namespace ConsoleApplication8
{
    class Program
    {
        public static void Main(string[] args)
        {
            int m, n, i, j;
            Console.Write("Enter Number Of Rows And Columns Of Matrices A and B : ");
            m = Convert.ToInt16(Console.ReadLine());
            n = Convert.ToInt16(Console.ReadLine());
            int[,] A = new int[10, 10];
            Console.Write("\nEnter The First Matrix : ");
            for (i = 0; i < m; i++)
            {
                for (j = 0; j < n; j++)
                {
                    A[i, j] = Convert.ToInt16(Console.ReadLine());
                }
            }

            int[,] B = new int[10, 10];
            Console.Write("\nEnter The Second Matrix:");
            for (i = 0; i < m; i++)
            {
                for (j = 0; j < n; j++)
                {
                    B[i, j] = Convert.ToInt16(Console.ReadLine());
                }
            }
            Console.Clear();
            Console.WriteLine("\nMatrix A : ");
            for (i = 0; i < m; i++)
            {
                for (j = 0; j < n; j++)
                {
                    Console.Write(A[i, j] + "\t");

                }
                Console.WriteLine();
            }
            Console.WriteLine("\nMatrix B: ");
            for (i = 0; i < m; i++)
            {
                for (j = 0; j < n; j++)
                {
                    Console.Write(B[i, j] + "\t");

                }
                Console.WriteLine();
            }
            int[,] C = new int[10, 10];
            for (i = 0; i < m; i++)
            {
                for (j = 0; j < n; j++)
                {
                    C[i, j] = A[i, j] + B[i, j];
                }
            }
            Console.Write("\nSum Matrix :");
            for (i = 0; i < m; i++)
            {
                for (j = 0; j < n; j++)
                {
                    Console.Write(C[i, j] + "\t");

                }
                Console.WriteLine();
            }
            Console.Read();
        }
    }
}