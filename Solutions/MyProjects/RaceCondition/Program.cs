using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RaceCondition
{
    public class Program
    {
        static int counter = 0;
        static void Main()
        {
            Thread t1 = new Thread(IncrementCounter);
            Thread t2 = new Thread(IncrementCounter);

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();

            Console.WriteLine("Final Counter: " + counter);

            Console.ReadLine();
        }

        static void IncrementCounter()
        {
            for (int i = 0; i < 1000000; i++)
            {
                counter++;
            }
        }
    }
}
