using System;

class BankAccount
{
    private decimal _balance;

    public BankAccount(decimal initialBalance)
    {
        _balance = initialBalance;
    }

    public decimal Balance
    {
        get { return _balance; }
    }

    public void Deposit(decimal amount)
    {
        if (amount > 0)
            _balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if (amount > 0 && amount <= _balance)
            _balance -= amount;
        else
            Console.WriteLine("Insufficient balance or invalid amount.");
    }
}

class Program
{
    static void Main()
    {
        BankAccount account = new BankAccount(500);
        account.Deposit(200);
        account.Withdraw(100);
        Console.WriteLine($"Current Balance: {account.Balance}");
    }
}
