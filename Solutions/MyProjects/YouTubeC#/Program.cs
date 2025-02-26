using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeC_
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Test test = new Test();
            //Console.ReadLine();
            DigitalCustomer digital = new DigitalCustomer("Ananth", 001);
            PhysicalCustomer phyObj = new PhysicalCustomer("Darshan", 002);
            ICustomer physical = new PhysicalCustomer("Darshan", 002);
            ICustomer castPhy = phyObj;
            digital.Details();
            physical.Details();
            phyObj.ShowDetails();
            castPhy.Details();

            Console.ReadLine();
            
        }
    }
}
