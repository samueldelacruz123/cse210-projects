using System;

class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(List<Product> products, Customer customer)
    {
        _products = products;
        _customer = customer;
    }

    public decimal GetTotalCost()
    {
        decimal total = 0;

        foreach(Product product in _products)
        {
            total += product.GetTotalCost();
        }

        decimal shippingCost = _customer.LivesInUsa() ? 5 : 35;
        total += shippingCost;

        return total;
    }

    public string GetPackingLabel()
    {
        string packingLabel = "Packing Label:\n";

        foreach (Product product in _products)
        {
            packingLabel += product.GetProductDetails() + "\n";
        }

        return packingLabel;
    }

    public string GetShippingLabel()
    {
        return "Shipping Label:\n" + _customer.GetCustomerInfo();
    }
}