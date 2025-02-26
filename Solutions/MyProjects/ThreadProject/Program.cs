using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace ThreadProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            Product obj = new Product(4);
  

            List<Customer> list = new List<Customer>();
                                                                                        
            Console.Write("Enter the Number of customers: ");
            int.TryParse(Console.ReadLine(), out int num);

            Console.WriteLine();

            for (int i = 0; i < num; i++)
            {
                Console.WriteLine("Enter the name of the customer");
                list.Add(new Customer(Console.ReadLine()));
            }  

            List<Thread> threads = new List<Thread>();

            foreach (Customer customer in list)
            {
                Thread thread = new Thread(customer.StartPurchasing);
                threads.Add(thread);
                thread.Start();
            }

            foreach (Thread thread in threads)
            {
                thread.Join(); 
            }
            Console.WriteLine("All Customers have finished purchasing.");

            Console.ReadLine();
        }
    }
}
