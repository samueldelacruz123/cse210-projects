using System;

class Program
{
    static void Main(string[] args)
    {
        Product product1 = new Product("Laptop", "LAP123", 1000m, 2);
        Product product2 = new Product("Mouse", "MSE456", 20m, 5);

        Address address = new Address("123 Main St", "New York", "NY", "USA");

        Customer customer = new Customer("John Doe", address);

        List<Product> products = new List<Product> { product1, product2 };
        Order order = new Order(products, customer);

        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine("Total Cost: $" + order.GetTotalCost());
    }
}