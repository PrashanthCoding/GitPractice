using System;

class BeverageSelection
{
    static void Main()
    {
        Console.WriteLine("Select a beverage (coffee, tea, juice): ");
        string beverage = Console.ReadLine().ToLower();

        switch (beverage)
        {
            case "coffee": Console.WriteLine("Here is your coffee."); break;
            case "tea": Console.WriteLine("Here is your tea."); break;
            case "juice": Console.WriteLine("Here is your juice."); break;
            default: Console.WriteLine("Invalid choice!"); break;
        }
    }
}
