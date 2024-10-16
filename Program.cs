/*
 * C# Program to Implement Delegates
 */
using System;
using System.IO;
delegate void delegatewriter(string message);
class delgwriter
{
    StreamWriter w;
    public delgwriter(string path)
    {
        w = File.CreateText(path);
    }
    public void display(string msg)
    {
        w.WriteLine(msg);
    }
    public void Flush()
    {
        w.Flush();
    }
    public void Close()
    {
        w.Close();
    }
}
class Test
{
    static delegatewriter delgwri;
    static void display(string s)
    {
        Console.WriteLine(s);
    }
    static void Main(string[] arg)
    {
        delgwriter x = new delgwriter("log.txt");
        delgwri += new delegatewriter(display);
        delgwri += new delegatewriter(x.display);
        delgwri("C");
        delgwri("C++");
        delgwri("C#");
        delgwri("Java");
        x.Flush();
        x.Close();
        Console.Read();
    }
}