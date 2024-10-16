/*
 * C# Program to Create an Instance of StackTrace and to Get all Frames
 */
using System;
using System.Diagnostics;
class program
{
    public static void Main()
    {
        StackTrace stackTrace = new StackTrace();
        StackFrame[] stackFrames = stackTrace.GetFrames();
        // write call stack method names
        Console.WriteLine("Method Names : ");
        foreach (StackFrame stackFrame in stackFrames)
        {
            Console.WriteLine(stackFrame.GetMethod().Name);
        }
        Console.Read();
    }
}