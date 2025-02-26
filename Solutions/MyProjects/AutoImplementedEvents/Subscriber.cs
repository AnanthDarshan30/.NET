using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutoImplementedEvents
{
    public class Subscriber
    {
        public void Add(int a, int b)
        {
            Console.WriteLine(a+b);
        }
        public Subscriber()
        {
        }
    }
}
