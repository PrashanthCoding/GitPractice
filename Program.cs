using System;
using System.Threading;

class Program
{
    static void Task()
    {
        for (int i = 1; i <= 5; i++)
        {
            Console.WriteLine($"Task {i}");
            Thread.Sleep(1000);
        }
    }

    static void Main()
    {
        Thread thread = new Thread(Task);
        thread.Start();
    }
}
