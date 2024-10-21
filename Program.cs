using System;

class Authentication
{
    static void Main()
    {
        Console.Write("Enter role (admin, user, guest): ");
        string role = Console.ReadLine().ToLower();

        switch (role)
        {
            case "admin": Console.WriteLine("Access granted: Full access"); break;
            case "user": Console.WriteLine("Access granted: Limited access"); break;
            case "guest": Console.WriteLine("Access granted: Guest access"); break;
            default: Console.WriteLine("Access denied!"); break;
        }
    }
}
