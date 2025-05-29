using System;
using System.Collections.Generic;

namespace ProductOrderingSystem
{
    // Address class
    public class Address
    {
        private string _street;
        private string _city;
        private string _stateOrProvince;
        private string _country;

        public Address(string street, string city, string stateOrProvince, string country)
        {
            _street = street;
            _city = city;
            _stateOrProvince = stateOrProvince;
            _country = country;
        }

        public bool IsInUSA()
        {
            return _country.ToUpper() == "USA";
        }

        public string GetFullAddress()
        {
            return $"{_street}\n{_city}, {_stateOrProvince}\n{_country}";
        }
    }

    // Customer class
    public class Customer
    {
        private string _name;
        private Address _address;

        public Customer(string name, Address address)
        {
            _name = name;
            _address = address;
        }

        public string GetName()
        {
            return _name;
        }

        public Address GetAddress()
        {
            return _address;
        }

        public bool IsInUSA()
        {
            return _address.IsInUSA();
        }
    }

    // Product class
    public class Product
    {
        private string _name;
        private string _productId;
        private double _price;
        private int _quantity;

        public Product(string name, string productId, double price, int quantity)
        {
            _name = name;
            _productId = productId;
            _price = price;
            _quantity = quantity;
        }

        public double GetTotalCost()
        {
            return _price * _quantity;
        }

        public string GetLabel()
        {
            return $"{_name} (ID: {_productId})";
        }
    }

    // Order class
    public class Order
    {
        private List<Product> _products;
        private Customer _customer;

        public Order(Customer customer)
        {
            _customer = customer;
            _products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public double GetTotalPrice()
        {
            double total = 0;
            foreach (Product product in _products)
            {
                total += product.GetTotalCost();
            }

            // Add shipping cost
            total += _customer.IsInUSA() ? 5.0 : 35.0;

            return total;
        }

        public string GetPackingLabel()
        {
            string label = "Packing Label:\n";
            foreach (Product product in _products)
            {
                label += $"- {product.GetLabel()}\n";
            }
            return label;
        }

        public string GetShippingLabel()
        {
            return $"Shipping Label:\n{_customer.GetName()}\n{_customer.GetAddress().GetFullAddress()}";
        }
    }

    // Main program
    class Program
    {
        static void Main(string[] args)
        {
            // First customer (USA)
            Address address1 = new Address("123 Main St", "Los Angeles", "CA", "USA");
            Customer customer1 = new Customer("John Smith", address1);

            Order order1 = new Order(customer1);
            order1.AddProduct(new Product("Wireless Mouse", "WM1001", 25.99, 2));
            order1.AddProduct(new Product("USB-C Cable", "UC2002", 9.99, 3));

            // Second customer (International)
            Address address2 = new Address("45 King St", "Toronto", "ON", "Canada");
            Customer customer2 = new Customer("Emily Chen", address2);

            Order order2 = new Order(customer2);
            order2.AddProduct(new Product("Laptop Stand", "LS3003", 39.99, 1));
            order2.AddProduct(new Product("Bluetooth Keyboard", "BK4004", 49.99, 1));
            order2.AddProduct(new Product("Monitor Light", "ML5005", 19.99, 2));

            // Display results
            List<Order> orders = new List<Order> { order1, order2 };

            foreach (Order order in orders)
            {
                Console.WriteLine(order.GetPackingLabel());
                Console.WriteLine(order.GetShippingLabel());
                Console.WriteLine($"Total Price: ${order.GetTotalPrice():0.00}");
                Console.WriteLine(new string('-', 40));
            }
        }
    }
}
