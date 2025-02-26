using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CollectionsPractice
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Customer> list = new List<Customer>();
            Customer c1 = new Customer { Custid = 10, Name = "Shiva", City = "Hyderabad", Balance = 25000.0 };
            Customer c2 = new Customer { Custid = 20, Name = "Dinesh", City = "Chennai", Balance = 20000.0 };
            Customer c3 = new Customer { Custid = 30, Name = "Anushka", City = "Delhi", Balance = 15000.0 };
            Customer c4 = new Customer { Custid = 40, Name = "Ananth", City = "Bangalore", Balance = 23000.0 };
            list.AddRange(new List<Customer> {c1,c2,c3,c4});

            foreach(Customer obj in list)
            {
                Console.WriteLine($"Customer Name = {obj.Name}, {Environment.NewLine}Customer ID = {obj.Custid},{Environment.NewLine}City = {obj.City}, {Environment.NewLine}Balance = {obj.Balance} ");
                Thread.Sleep(1000);
            }


            Console.ReadLine();
        }
    }
}
