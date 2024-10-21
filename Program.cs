using System;

class ATMMenu
{
    static void Main()
    {
        Console.WriteLine("ATM Menu:");
        Console.WriteLine("1. Check Balance");
        Console.WriteLine("2. Deposit Money");
        Console.WriteLine("3. Withdraw Money");
        Console.WriteLine("4. Exit");
        Console.Write("Choose an option: ");
        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                Console.WriteLine("Your balance is $1000.");
                break;
            case 2:
                Console.WriteLine("Enter deposit amount: ");
                break;
            case 3:
                Console.WriteLine("Enter withdrawal amount: ");
                break;
            case 4:
                Console.WriteLine("Exiting...");
                break;
            default:
                Console.WriteLine("Invalid choice!");
                break;
        }
    }
}
