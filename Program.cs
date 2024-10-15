using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        BlockingCollection<int> collection = new BlockingCollection<int>(5);

        Task producer = Task.Run(() =>
        {
            for (int i = 0; i < 10; i++)
            {
                collection.Add(i);
                Console.WriteLine($"Produced: {i}");
                Task.Delay(500).Wait();
            }
            collection.CompleteAdding();
        });

        Task consumer = Task.Run(() =>
        {
            foreach (var item in collection.GetConsumingEnumerable())
            {
                Console.WriteLine($"Consumed: {item}");
                Task.Delay(1000).Wait();
            }
        });

        Task.WaitAll(producer, consumer);
        Console.WriteLine("All work is done.");
    }
}
