using System;
using System.Text;

class Program
{
    static void Main()
    {
        int length = 12;
        string password = GeneratePassword(length);
        Console.WriteLine($"Generated Password: {password}");
    }

    static string GeneratePassword(int length)
    {
        const string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()";
        StringBuilder res = new StringBuilder();
        Random rnd = new Random();

        while (0 < length--)
        {
            res.Append(validChars[rnd.Next(validChars.Length)]);
        }
        return res.ToString();
    }
}
