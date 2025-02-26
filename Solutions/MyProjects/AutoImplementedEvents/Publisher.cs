using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutoImplementedEvents
{
    public delegate void MyDelegateType(int a,int b);
    public class Publisher
    {
        public event MyDelegateType MyEvent;

        public void RaiseEvent(int a,int b)
        {
            MyEvent?.Invoke(a, b);
        }
        public Publisher()
        {
        }
    }
}
