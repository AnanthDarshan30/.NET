using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the string to reverse: ");
            string value = Console.ReadLine();
            for (int i = value.Length - 1; i >= 0; i--)
            {
                Console.Write(value[i]);
            }
            Console.WriteLine();
            Console.WriteLine(args[0].Length);
            //Console.WriteLine(value);

            Console.ReadLine();
        }
    }
}
