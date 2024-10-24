using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        await PerformTask();
        Console.WriteLine("Main method completed");
    }

    static async Task PerformTask()
    {
        Console.WriteLine("Task started...");
        await Task.Delay(3000);
        Console.WriteLine("Task completed!");
    }
}
