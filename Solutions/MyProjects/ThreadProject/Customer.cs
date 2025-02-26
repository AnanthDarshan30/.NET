using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadProject
{
    public class Customer
    {
        private readonly string _name;
        
        public void StartPurchasing()
        {
            Thread thread = new Thread(() => Product.Purchase(_name));
            thread.Start();
            thread.Join();
        }
        public Customer(string name)
        {
            _name = name;
        }
    }
}
