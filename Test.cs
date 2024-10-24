using System;

public delegate void Notify();

class Process
{
    public event Notify ProcessCompleted;

    public void StartProcess()
    {
        Console.WriteLine("Process started...");
        OnProcessCompleted();
    }

    protected virtual void OnProcessCompleted()
    {
        if (ProcessCompleted != null)
        {
            ProcessCompleted();
        }
    }
}

class Program
{
    static void Main()
    {
        Process process = new Process();
        process.ProcessCompleted += ProcessCompletedHandler;
        process.StartProcess();
    }

    static void ProcessCompletedHandler()
    {
        Console.WriteLine("Process Completed!");
    }
}
