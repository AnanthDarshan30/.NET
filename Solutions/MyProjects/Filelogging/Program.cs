using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileLogger;

namespace ThrowException
{
    class Program
    {
        static void Main(string[] args)
        {
            // Configure the logger to log to a specific 
            Logger.Configure(@"C:\Users\aadars\SampleFiles\log.txt");

            try
            {
                Logger.Debug("Starting to process the array.");
                ProcessArray();
                Logger.Debug("Array processing completed successfully.");
                
            }
            catch (Exception ex)
            {
                Logger.Error($"Caught exception:{ex.Message}");
                if (ex.InnerException != null)
                {
                    Logger.Error($"Inner exception: {ex.InnerException.Message}");
                }
            }
            Console.ReadLine();
        }

        static void ProcessArray()
        {
            int[] numbers = { 1, 2, 3, 4, 5 };

            try
            {
                Logger.Debug("Attempting to access array element.");
                Console.WriteLine(numbers[4]);  //indexoutofrange

                object[] objArray = new object[numbers.Length];

                for (int i = 0; i < numbers.Length; i++)
                {
                    objArray[i] = numbers[i];
                }

                Logger.Debug("Attempting to cast object array to string array.");
                string[] stringArray = (string[])objArray;  
            }
            catch (IndexOutOfRangeException ex)
            {
                Logger.Warning("Caught IndexOutOfRangeException");
                
                throw;
            }
            catch (InvalidCastException ex)
            {
                Logger.Warning("Caught InvalidCastException");

                // Log the exception and throw a new exception with details
                Logger.Error("Invalid operation while processing the array.");
                throw new Exception("Invalid operation while processing the array.", ex);
            }
        }
    }
}


