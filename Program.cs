using System;

class AnimalSounds
{
    static void Main()
    {
        Console.WriteLine("Enter an animal (dog, cat, cow, lion): ");
        string animal = Console.ReadLine().ToLower();

        switch (animal)
        {
            case "dog": Console.WriteLine("Dog says: Woof!"); break;
            case "cat": Console.WriteLine("Cat says: Meow!"); break;
            case "cow": Console.WriteLine("Cow says: Moo!"); break;
            case "lion": Console.WriteLine("Lion says: Roar!"); break;
            default: Console.WriteLine("Unknown animal!"); break;
        }
    }
}
