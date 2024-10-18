using System;

namespace ReverseAnArrayDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Creating an Integer Array
            int[] arr = { 1, 2, 3, 4, 5 };

            Console.Write("Original Array Elements :");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }

            ReverseElements(arr, 0, (arr.Length - 1));

            Console.Write("\nReversed Array Elements :");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }

            Console.ReadKey();
        }

        public static void ReverseElements(int[] arr, int startIndex, int endIndex)
        {
            while (startIndex < endIndex)
            {
                int temp = arr[startIndex];
                arr[startIndex] = arr[endIndex];

                arr[endIndex] = temp;

                startIndex++;
                endIndex--;
            }
        }
    }
}