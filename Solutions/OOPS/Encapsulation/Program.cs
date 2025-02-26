using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sharedlibrary;
using Sharelibrary;

namespace Encapsulation
{
    public class SecureOrder
    {
        private int _orderId;
        private List<Product> _products;
        private Customer _customer;

        public SecureOrder()
        {
            _products = new List<Product>();
        }

        public void SetOrderDetails(int orderId, Customer customer)
        {
            _orderId = orderId;
            _customer = customer;
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public decimal CalculateTotal()
        {
            return _products.Sum(p => p.Price);
        }

        public string GetOrderDetails()
        {
            return $"Order ID: {_orderId}, Customer: {_customer.Name}, Total Products: {_products.Count}";
        }
    }
}

