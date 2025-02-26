using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Events
{
    public class Subscriber
    {
        public void Add(int a, int b) 
        {
            Console.WriteLine(a + b);
        }
        public void print(int a)
        {
            Console.WriteLine(a);
        }
        public Subscriber()
        {
        }
    }
}
