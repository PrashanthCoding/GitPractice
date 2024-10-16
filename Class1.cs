using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Starting tasks...");
        Task task1 = Task.Run(() => PerformTask(1, 2000));
        Task task2 = Task.Run(() => PerformTask(2, 1000));

        await Task.WhenAll(task1, task2);
        Console.WriteLine("All tasks completed.");
    }

    static void PerformTask(int taskId, int delay)
    {
        Console.WriteLine($"Task {taskId} is running...");
        Task.Delay(delay).Wait();
        Console.WriteLine($"Task {taskId} completed.");
    }
}
