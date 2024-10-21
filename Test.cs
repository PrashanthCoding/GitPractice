using System;

namespace Console_DateTime
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime TodayNoon = new DateTime(2018, 9, 13, 12, 0, 0);
            DateTime TodayMidnight = new DateTime(2018, 9, 12, 0, 0, 0);
            TimeSpan Result = TodayNoon.Subtract(TodayMidnight);
            Console.WriteLine($"Yesterday Midnight - Today Noon = {Result.Days}");
            Console.WriteLine($"Yesterday Midnight - Today Noon = {Result.TotalDays}");
            Console.ReadLine();
        }
    }
}