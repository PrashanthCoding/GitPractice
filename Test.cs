using System;

class Program
{
    static void PrintMessage(string message)
    {
        Console.WriteLine("Action Delegate: " + message);
    }

    static void Main()
    {
        Action<string> action = PrintMessage;
        action("Hello from Action delegate!");
    }
}
