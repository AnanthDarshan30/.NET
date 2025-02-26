using System;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime;

/*
 * IndexOutOfBound Exception
 * DivideByZero Exception
 * Overflow Exception
 * Format Exception
 * Custom Exception
 */

namespace ExceptionHandling
{
    
    public class CustomException : Exception
    {
        public CustomException(string message) : base(message)
        {

        }

        //public class Exception
        //{
        //    private string _message;

        //    public Exception(string message)
        //    {
        //        _message = message;
        //    }

        //    public virtual string Message => _message;
        //}
    }

    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter the 1st Number: ");
                int x = int.Parse(Console.ReadLine());

               
                if (x == 42)
                {
                    throw new CustomException("You cannot use the number 42 for this operation!");
                }

                Console.Write("Enter 2nd Number: ");
                int y = int.Parse(Console.ReadLine());

                
                int z = x / y;
                Console.WriteLine($"The result is : {z} ");
            }
            
            catch (DivideByZeroException Ex1)
            {
                Console.WriteLine($"Error: {Ex1.Message}");
            }
            // using filter
            catch (OverflowException Ex2) when (Ex2.Message.Contains("negative"))
            {
                //
                Console.WriteLine($"Overflow error (with filter): {Ex2.Message}");
            }
            
            catch (FormatException Ex3)
            {
                Console.WriteLine(Ex3.Message);
            }
            
            catch (CustomException Ex4)
            {
                Console.WriteLine($"Custom Exception: {Ex4.Message}");
            }
            
            catch (Exception Ex5)
            {
                Console.WriteLine($"Some random exception is caught, default message - {Ex5.Message}");
            }
            finally // used to release resources and execute important commands that must run
            {
                Console.WriteLine("End of the Program");
            }
            Console.ReadLine();
        }
    }
}



