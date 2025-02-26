using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Locks
{
    public class Program
    {
        static int counter = 0;
        private static readonly object _lockObject = new object();

        static void Main(string[] args)
        {
            Thread thread = new Thread(Increment);
            Thread thread1 = new Thread(Increment);

            thread.Start();
            thread1.Start();

            thread.Join();
            thread1.Join();

            System.Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"After incrementing the counter, final value is {counter}");
            Console.ReadLine();
        }
        static void Increment()
        {
            for(int i = 0; i < 1000000; i++)
            {
                lock(_lockObject)
                {
                    counter++; 
                }
            }
        }
    }
}
