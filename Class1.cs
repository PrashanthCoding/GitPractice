using System;

class MovieGenre
{
    static void Main()
    {
        Console.WriteLine("Enter movie genre (action, comedy, drama): ");
        string genre = Console.ReadLine().ToLower();

        switch (genre)
        {
            case "action": Console.WriteLine("You chose Action: Expect high energy!"); break;
            case "comedy": Console.WriteLine("You chose Comedy: Get ready to laugh!"); break;
            case "drama": Console.WriteLine("You chose Drama: Prepare for an emotional ride."); break;
            default: Console.WriteLine("Unknown genre!"); break;
        }
    }
}
