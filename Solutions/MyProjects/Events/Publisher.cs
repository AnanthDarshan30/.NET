using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Events
{
    //delegate type required before declaring event
    public delegate void MyDelegateType(int a, int b);
    public delegate void MyDelegateType2(int a);
    public class Publisher
    {
        private MyDelegateType MyDelegate; //to store one or more methods reference
        public event MyDelegateType MyEvent
        {
            add
            {
                MyDelegate += value;//value is the method assigned from the subcriber class
            }
            remove
            {
                MyDelegate -= value;
            }
        }
        public void RaiseEvent(int a, int b)
        {
            if (MyDelegate != null)
            {
                MyDelegate(a, b);
            }

        }
        public Publisher()
        {
        }
    }
}
