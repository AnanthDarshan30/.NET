using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThrowException
{

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ProcessArray();
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Caught exception: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner exception: {ex.InnerException.Message}");
                }
                Console.ReadLine();
            }
        }

        static void ProcessArray()
        {
            int[] numbers = { 1, 2, 3, 4, 5 };

            try
            {
                
                Console.WriteLine(numbers[4]);  // This will throw an IndexOutOfRangeException

                object[] objArray = new object[numbers.Length];

                for (int i = 0; i < numbers.Length; i++)
                {
                    objArray[i] = numbers[i];  
                }
                string[] stringArray = (string[])objArray;  // This will throw an InvalidCastException
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("Caught IndexOutOfRangeException");
                throw;  // Re-throwing the same exception, useful for stack-trace
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine("Caught InvalidCastException");

                // Innner exception
                throw new Exception("Invalid operation while processing the array.", ex);
            }
        }
    }

}
