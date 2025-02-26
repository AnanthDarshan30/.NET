using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.CompilerServices;

namespace MultiThreading
{
    public class Program
    {
        public void CountUp()
        {  
            for (int i = 0; i < 100; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"i = {i}, ");
            }
        }
        public void CountDown()
        {
            for (int i = 100; i >= 0; i--)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"j = {i}, ");
            }
        }
        static void Main(string[] args)
        {

            Thread mainThread = Thread.CurrentThread;
            mainThread.Name = "Main Thread";
            Console.WriteLine($"Name of the thread is : {mainThread.Name}");
            Program program = new Program();

            //Console.Write("Enter the number of iterations of count up and count down: ");
            //int.TryParse(Console.ReadLine(), out int num);

            ThreadStart threadStart = new ThreadStart(program.CountUp);
            Thread thread1 = new Thread(threadStart);

            ThreadStart threadStart2 = new ThreadStart(program.CountDown);
            Thread thread2 = new Thread(threadStart2);

            thread1.Start();
            Console.WriteLine($"Thread 1 is {thread1.ThreadState.ToString()}");

            thread2.Start();
            Console.WriteLine($"Thread 1 is {thread2.ThreadState.ToString()}");

            
            Console.ReadKey();
        }   

    }
}
