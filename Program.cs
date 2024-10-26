using System;

class BankAccount
{
    public virtual void CalculateInterest() => Console.WriteLine("Calculating interest for bank account.");
}

class SavingsAccount : BankAccount
{
    public override void CalculateInterest() => Console.WriteLine("Interest calculated at 4% for savings account.");
}

class Program
{
    static void Main()
    {
        BankAccount acc = new SavingsAccount();
        acc.CalculateInterest();
    }
}
