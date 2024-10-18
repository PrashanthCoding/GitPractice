using System;
class Demo
{
    public static void Main()
    {
        int decValue, counter, i = 1, j;
        int[] octalValue = new int[80];
        decValue = 127;
        counter = decValue;
        Console.WriteLine("Decimal Number:{0}", decValue);
        while (counter != 0)
        {
            octalValue[i++] = counter % 8;
            counter /= 8;
        }

        Console.Write("Octal Number: ");
        for (j = i - 1; j > 0; j--)
            Console.Write(octalValue[j]);
        Console.Read();
    }
}