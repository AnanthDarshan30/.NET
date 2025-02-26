using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sharedlibrary;

namespace Sharelibrary

{
    public class Order
    {
        public int OrderId { get; set; }
        public string Customer { get; set; }
        public List<Product> Products { get; set; }

        public Order(int orderId, Customer customer)
        {
            OrderId = orderId;
            Customer = customer.Name;
            Products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }

        public decimal CalculateTotal()
        {
            return Products.Sum(p => p.Price);
        }
    }
}
