using System;

namespace Console_DateTime
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime dtTodayNoon = new DateTime(2018, 9, 13, 12, 0, 0);
            DateTime dtTodayMidnight = new DateTime(2018, 9, 12, 0, 0, 0);
            TimeSpan diffResult = dtTodayNoon.Subtract(dtTodayMidnight);
            Console.WriteLine($"Yesterday Midnight - Today Noon = {diffResult.Days}");
            Console.WriteLine($"Yesterday Midnight - Today Noon = {diffResult.TotalDays}");
            Console.ReadLine();
        }
    }
}