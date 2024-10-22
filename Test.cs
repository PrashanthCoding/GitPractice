using System;

class MenuSelection
{
    static void Main()
    {
        Console.WriteLine("1. View Profile");
        Console.WriteLine("2. Edit Profile");
        Console.WriteLine("3. Logout");
        Console.Write("Enter your choice: ");
        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1: Console.WriteLine("Displaying Profile..."); break;
            case 2: Console.WriteLine("Editing Profile..."); break;
            case 3: Console.WriteLine("Logging Out..."); break;
            default: Console.WriteLine("Invalid Choice!"); break;
        }
    }
}
