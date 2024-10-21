using System;

class FruitSelection
{
    static void Main()
    {
        Console.Write("Choose a fruit (apple, banana, mango): ");
        string fruit = Console.ReadLine().ToLower();

        switch (fruit)
        {
            case "apple": Console.WriteLine("Apple is red or green."); break;
            case "banana": Console.WriteLine("Banana is yellow."); break;
            case "mango": Console.WriteLine("Mango is sweet."); break;
            default: Console.WriteLine("Unknown fruit!"); break;
        }
    }
}
