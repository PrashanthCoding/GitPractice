
// Start date
using System;

DateTime startDate = new DateTime(2005, 2, 1, 3, 4, 12, 56);
// End date
DateTime endDate = new DateTime(2005, 12, 12, 4, 30, 45, 12);
// Time span
TimeSpan diffDate = endDate.Subtract(startDate);
// Spit it out
Console.WriteLine("Time Difference: ");
Console.WriteLine(diffDate.Days.ToString() + " Days");
Console.WriteLine(diffDate.Hours.ToString() + " Hours");
Console.WriteLine(diffDate.Minutes.ToString() + " Minutes");
Console.WriteLine(diffDate.Seconds.ToString() + " Seconds ");
Console.WriteLine(diffDate.Milliseconds.ToString() + " Milliseconds ");