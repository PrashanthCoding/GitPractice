using System;
namespace DotNetTutorials
{
    public class ReversalAlgorithm
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7 };
            Console.WriteLine("Original Array is :");
            for (int i = 0; i < arr.Length; i++)
                Console.Write(arr[i] + " ");

            Console.WriteLine();

            Console.Write("Enter value of k:");
            int position = Convert.ToInt32(Console.ReadLine());
            ReversalAlgorithm obj = new ReversalAlgorithm();
            obj.SwapElements(arr, 0, (position - 1));// 1st part
            obj.SwapElements(arr, position, (arr.Length - 1));//2nd 
            obj.SwapElements(arr, 0, (arr.Length - 1));

            Console.WriteLine();

            Console.WriteLine("Rotation of array by position " + position);
            for (int i = 0; i < arr.Length; i++)
                Console.Write(arr[i] + " ");

            Console.ReadKey();
        }

        //3 times
        void SwapElements(int[] arr, int startIndex, int endIndex)
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