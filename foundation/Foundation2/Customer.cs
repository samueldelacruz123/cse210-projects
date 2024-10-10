using System;

class Customer
{
    private string _name;
    private Address _address;

    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    public bool LivesInUsa()
    {
        return _address.InUsa();
    }

    public string GetCustomerInfo()
    {
        return $"{_name}\n{_address.GetFullAddress()}";
    }
}