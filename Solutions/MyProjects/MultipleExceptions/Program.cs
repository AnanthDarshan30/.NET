using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleExceptions
{
    internal class Program
    {
        public static void DivideByZero(string s, string c)
        {
            try
            {
                int x = int.Parse(s);
                int y = int.Parse(c);
                int z = x/y;
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Error has occured: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Some error has occured.{ex.Message}");
            }
        }
        public static void Format(string s, string c)
        {
            try
            {
                int x = int.Parse(s);
                int y = int.Parse(c);
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Error has occured: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Some error has occured.{ex.Message}");
            }
        }
        public static void OverFlow(string s,string c)
        {
            try
            {
                int x = int.Parse(s);
                int y = int.Parse(c);

            }
            catch (OverflowException ex)
            {
                Console.WriteLine($"Error has occured: {ex.Message}");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Some error has occured.{ex.Message}");
            }
        }
        static void Main(string[] args)
        {
            Console.Write("Enter 1st number: ");
            string s = Console.ReadLine();
            Console.Write("Enter 2nd number: ");
            string c = Console.ReadLine();

            DivideByZero(s,c);
            OverFlow(s,c);
            Format(s,c);
            


            Console.ReadLine();
        }
    }
}
