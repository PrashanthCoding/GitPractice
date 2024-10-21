using System;

namespace DateTimeFormatInCSharpSample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get current DateTime. It can be any DateTime object in your code.
            DateTime Date = DateTime.Now;

            // Format Datetime in different formats and display them
            Console.WriteLine(Date.ToString("MM/dd/yyyy"));
            Console.WriteLine(Date.ToString("dddd, dd MMMM yyyy"));
            Console.WriteLine(Date.ToString("dddd, dd MMMM yyyy"));
            Console.WriteLine(Date.ToString("dddd, dd MMMM yyyy"));
            Console.WriteLine(Date.ToString("dddd, dd MMMM yyyy"));
            Console.WriteLine(Date.ToString("dddd, dd MMMM yyyy"));
            Console.WriteLine(Date.ToString("dddd, dd MMMM yyyy HH:mm:ss"));
            Console.WriteLine(Date.ToString("MM/dd/yyyy HH:mm"));
            Console.WriteLine(Date.ToString("MM/dd/yyyy hh:mm tt"));
            Console.WriteLine(Date.ToString("MM/dd/yyyy H:mm"));
            Console.WriteLine(Date.ToString("MM/dd/yyyy h:mm tt"));
            Console.WriteLine(Date.ToString("MM/dd/yyyy HH:mm:ss"));
            Console.WriteLine(Date.ToString("MMMM dd"));
            Console.WriteLine(Date.ToString("yyyy’-‘MM’-‘dd’T’HH’:’mm’:’ss.fffffffK"));
            Console.WriteLine(Date.ToString("ddd, dd MMM yyy HH’:’mm’:’ss ‘GMT’"));
            Console.WriteLine(Date.ToString("yyyy’-‘MM’-‘dd’T’HH’:’mm’:’ss"));
            Console.WriteLine(Date.ToString("HH:mm"));
            Console.WriteLine(Date.ToString("hh:mm tt"));
            Console.WriteLine(Date.ToString("H:mm"));
            Console.WriteLine(Date.ToString("h:mm tt"));
            Console.WriteLine(Date.ToString("HH:mm:ss"));
            Console.WriteLine(Date.ToString("yyyy MMMM"));

            Console.ReadKey();
        }
    }
}