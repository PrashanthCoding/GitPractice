using System;

class Product
{
    public string Name;
    public double Price;

    public Product()
    {
        Name = "Unknown";
        Price = 0.0;
    }

    public Product(string name)
    {
        Name = name;
        Price = 0.0;
    }

    public Product(string name, double price)
    {
        Name = name;
        Price = price;
    }

    public void Display()
    {
        Console.WriteLine($"Product Name: {Name}, Price: {Price}");
    }
}

class Program
{
    static void Main()
    {
        Product product1 = new Product();
        Product product2 = new Product("Laptop");
        Product product3 = new Product("Smartphone", 299.99);

        product1.Display();
        product2.Display();
        product3.Display();
    }
}
