using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_MethodImplementation_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Laptop laptop = new Laptop();
            Default defaultLaptop = laptop;
            laptop.SetId(1);
            laptop.Display();
            defaultLaptop.Display();
            Desktop desktop = new Desktop();
            desktop.Display();

            Console.ReadLine();
        }
    }
}
