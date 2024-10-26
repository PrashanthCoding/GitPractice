using System;

interface IPlayable
{
    void Play();
}

class Video : IPlayable
{
    public void Play() => Console.WriteLine("Playing video...");
}

class Audio : IPlayable
{
    public void Play() => Console.WriteLine("Playing audio...");
}

class Program
{
    static void Main()
    {
        IPlayable video = new Video();
        IPlayable audio = new Audio();
        video.Play();
        audio.Play();
    }
}
