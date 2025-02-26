using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PaymentGateway 
{
    public interface IPayment
    {
        void ProcessPayment(decimal amount);
    }
    public class Payment
    {
        //public void ProcessPayment(decimal amount);
        public void Display(decimal amount)
        {
            Console.WriteLine($"Amount {amount} is being processed...");
        }
    }
    class CreditCard : Payment, IPayment
    {
        public void ProcessPayment(decimal amount)
        {
            //throw new NotImplementedException();
            if (amount > 0)
            {
                Display(amount);
                Thread.Sleep(2000);
                Console.WriteLine("Credit card Payment has been processed.");

            }
            else
            {
                Console.WriteLine("The amount you are trying to process is invalid.");
            }
        }
    }
    class UPI : Payment, IPayment
    {
        public void ProcessPayment(decimal amount)
        {
            //throw new NotImplementedException();
            if (amount > 0)
            {
                Display(amount);
                Thread.Sleep(2000);
                Console.WriteLine("UPI Payment has been processed.");

            }
            else
            {
                Console.WriteLine("The amount you are trying to process is invalid.");
            }
        }
    }
    public class Processor
    {
        private IPayment _payment;
        public Processor(IPayment payment)
        {
            _payment = payment;
        }
        public void ProcessPayment(decimal amount)
        {
            _payment.ProcessPayment(amount);
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            IPayment Creditcard = new CreditCard();
            IPayment Upi = new UPI();
            Processor Cc = new Processor(Creditcard);
            Cc.ProcessPayment(666m);
            Thread.Sleep(2000);
            Processor U = new Processor(Upi);
            U.ProcessPayment(540.67m);

            Console.ReadLine();
        }
    }
}
