using System;
using System.Collections.Generic;

// Product class
public class Product
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }

    public Product(int id, string name, decimal price, int stock)
    {
        ProductId = id;
        ProductName = name;
        Price = price;
        Stock = stock;
    }

    public void DisplayProduct()
    {
        Console.WriteLine($"ID: {ProductId}, Name: {ProductName}, Price: {Price}, Stock: {Stock}");
    }
}

// Customer class
public class Customer
{
    public int CustomerId { get; set; }
    public string CustomerName { get; set; }
    public string Email { get; set; }
    public List<Order> Orders { get; set; } = new List<Order>();

    public Customer(int id, string name, string email)
    {
        CustomerId = id;
        CustomerName = name;
        Email = email;
    }

    public void DisplayCustomer()
    {
        Console.WriteLine($"ID: {CustomerId}, Name: {CustomerName}, Email: {Email}");
    }
}

// CartItem class
public class CartItem
{
    public Product Product { get; set; }
    public int Quantity { get; set; }

    public CartItem(Product product, int quantity)
    {
        Product = product;
        Quantity = quantity;
    }

    public decimal TotalPrice()
    {
        return Product.Price * Quantity;
    }

    public void DisplayCartItem()
    {
        Console.WriteLine($"Product: {Product.ProductName}, Quantity: {Quantity}, Total: {TotalPrice()}");
    }
}

// ShoppingCart class
public class ShoppingCart
{
    public List<CartItem> Items { get; set; } = new List<CartItem>();

    public void AddItem(Product product, int quantity)
    {
        var existingItem = Items.Find(i => i.Product.ProductId == product.ProductId);
        if (existingItem != null)
        {
            existingItem.Quantity += quantity;
        }
        else
        {
            Items.Add(new CartItem(product, quantity));
        }
    }

    public void DisplayCart()
    {
        Console.WriteLine("Cart Items:");
        foreach (var item in Items)
        {
            item.DisplayCartItem();
        }
    }

    public decimal GetCartTotal()
    {
        decimal total = 0;
        foreach (var item in Items)
        {
            total += item.TotalPrice();
        }
        return total;
    }

    public void Checkout(Customer customer)
    {
        Console.WriteLine("\n--- Checkout Process ---");
        Console.WriteLine($"Customer: {customer.CustomerName}");
        foreach (var item in Items)
        {
            item.Product.Stock -= item.Quantity;
        }

        customer.Orders.Add(new Order(customer.CustomerId, this));

        Console.WriteLine("Order placed successfully!");
        Console.WriteLine($"Total: {GetCartTotal()}");

        Items.Clear();
    }
}

// Order class
public class Order
{
    public int OrderId { get; set; }
    public int CustomerId { get; set; }
    public List<CartItem> OrderItems { get; set; }
    public DateTime OrderDate { get; set; }

    public Order(int customerId, ShoppingCart cart)
    {
        OrderId = new Random().Next(1000, 9999); // Generate a random order ID
        CustomerId = customerId;
        OrderItems = new List<CartItem>(cart.Items);
        OrderDate = DateTime.Now;
    }

    public void DisplayOrder()
    {
        Console.WriteLine($"\nOrder ID: {OrderId}, Customer ID: {CustomerId}, Date: {OrderDate}");
        foreach (var item in OrderItems)
        {
            Console.WriteLine($"Product: {item.Product.ProductName}, Quantity: {item.Quantity}");
        }
    }
}

// Main Program
class ECommerceSystem
{
    static void Main(string[] args)
    {
        // Sample products
        Product product1 = new Product(1, "Laptop", 1500, 10);
        Product product2 = new Product(2, "Smartphone", 700, 20);
        Product product3 = new Product(3, "Tablet", 400, 15);

        // Displaying available products
        Console.WriteLine("--- Available Products ---");
        product1.DisplayProduct();
        product2.DisplayProduct();
        product3.DisplayProduct();

        // Customer creation
        Customer customer = new Customer(1, "John Doe", "john@example.com");
        Console.WriteLine("\n--- Customer Details ---");
        customer.DisplayCustomer();

        // Shopping Cart
        ShoppingCart cart = new ShoppingCart();

        // Adding items to cart
        cart.AddItem(product1, 1); // 1 Laptop
        cart.AddItem(product2, 2); // 2 Smartphones

        // Displaying cart details
        Console.WriteLine("\n--- Cart Details ---");
        cart.DisplayCart();

        // Checking out
        cart.Checkout(customer);

        // Displaying customer's orders
        Console.WriteLine("\n--- Customer Orders ---");
        foreach (var order in customer.Orders)
        {
            order.DisplayOrder();
        }

        // Display remaining stock
        Console.WriteLine("\n--- Updated Product Stock ---");
        product1.DisplayProduct();
        product2.DisplayProduct();
        product3.DisplayProduct();
    }
}
