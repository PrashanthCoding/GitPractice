using System;

class Book
{
    private string title;
    private double price;

    public string Title
    {
        get { return title; }
        set { title = value; }
    }

    public double Price
    {
        get { return price; }
        set
        {
            if (value > 0)
                price = value;
            else
                Console.WriteLine("Price must be positive.");
        }
    }
}

class Program
{
    static void Main()
    {
        Book book = new Book();
        book.Title = "C#";
        book.Price = 19.99;

        Console.WriteLine($"Title: {book.Title}, Price: {book.Price}");
    }
}
