using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the table number: ");
            int.TryParse(Console.ReadLine(), out var num);
            Console.Write("Enter the length required: ");
            int.TryParse(Console.ReadLine(), out var val);
            int[] result = new int[val];

            for(int i = 0; i < val; i++)
            {
                result[i] = num * (i+1);
            }
            foreach (int i in result)
            {
                Console.WriteLine(i);
            }

            Console.ReadLine();
        }
    }
}
