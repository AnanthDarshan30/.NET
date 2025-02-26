using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadProject
{
    public class Product
    {
        private static int _stock;
        private static object _lock = new object();
        public static void Purchase(string customerName)
        {
            lock(_lock)
            {
                if(_stock>0)
                {
                    Console.WriteLine($"{customerName} is purchasing the product.");
                    _stock--;
                    Console.WriteLine($"Remaining stock after purchase is: {_stock}");
                }
                else
                {
                    Console.WriteLine($"Not enough stock remaining to purchase your product" + Environment.NewLine);
                }
            }
        }
        public Product(int stock)
        {
            _stock = stock;
        }
    }
}
