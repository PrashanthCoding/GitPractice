using System;

class InstrumentSounds
{
    static void Main()
    {
        Console.WriteLine("Enter a musical instrument (guitar, piano, drum): ");
        string instrument = Console.ReadLine().ToLower();

        switch (instrument)
        {
            case "guitar": Console.WriteLine("Strum!"); break;
            case "piano": Console.WriteLine("Pling!"); break;
            case "drum": Console.WriteLine("Boom!"); break;
            default: Console.WriteLine("Unknown instrument!"); break;
        }
    }
}
