using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Threads
{
    public class Program
    {
        static void Main(string[] args)
        {
            Thread mainThread = Thread.CurrentThread;
            mainThread.Name = "Main thread";

            ThreadPriority priority = mainThread.Priority;


            System.Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Name of the main thread is: {mainThread.Name}");

            System.Console.ForegroundColor= ConsoleColor.Red;
            Console.WriteLine($"Priority level of main thread is : {priority}");

            bool active = mainThread.IsAlive;
            string state = null;

            if (active)
            {
                state = "Running.";
            }
            else
            {
                state = "not running and execution is completed.";
            }

            System.Console.ForegroundColor = System.ConsoleColor.DarkCyan;
            Console.WriteLine($"the thread currently is {state}");
            Console.ReadLine();
        }
    }
}
