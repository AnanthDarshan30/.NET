using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplicationTables
{
    class Program
    {
        static void Main(string[] args)
        {
            bool flag = true;
            while (flag)
            {
                Console.Write("Enter the number you want the table of : ");
                bool success = int.TryParse(Console.ReadLine(), out int number);
                if (!success) { Console.WriteLine("Not the right Number Format for Int32"); return; }
                for (int i = 1; i <= 10; i++)
                {
                    Console.WriteLine("{0} x {1} = {2}", number, i, number * i);
                }
                String val = Console.ReadLine();
                if(val == "exit" || val == "Exit" || val == "EXIT") {
                    Console.WriteLine("Hope I was Helpful!! ^_^");
                    Console.ReadLine();
                    flag = false; 
                }   
            }
        }
    }
}
