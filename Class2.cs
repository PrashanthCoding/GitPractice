using System;

class FruitPrice
{
    static void Main()
    {
        Console.WriteLine("Enter fruit (apple, banana, orange): ");
        string fruit = Console.ReadLine().ToLower();

        switch (fruit)
        {
            case "apple":
                Console.WriteLine("Apple price is $2 per kg.");
                break;
            case "banana":
                Console.WriteLine("Banana price is $1 per dozen.");
                break;
            case "orange":
                Console.WriteLine("Orange price is $3 per kg.");
                break;
            default:
                Console.WriteLine("Unknown fruit!");
                break;
        }
    }
}
