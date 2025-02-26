using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayAlgo
{
    class Program
    {
        static Boolean LinearSearch(int[] input, int n)
        {
            foreach (int current in input)
            {
                if (current == n)
                {
                    return true;
                }
            }
                return false;
        }
        static void Main(string[] args)
        {
            Console.Write("Enter your array of integers by separating them with commas(,): ");
            string[] array = Console.ReadLine().Split(',');
            int[] input = array.Select(x => int.Parse(x)).ToArray();
            Console.Write("Enter the number to search in the array: ");
            int.TryParse(Console.ReadLine(), out int n);
            bool result = LinearSearch(input, n);
            if (result) Console.WriteLine("Element found.");
            else Console.WriteLine("Element not found");
        }
    }
}
