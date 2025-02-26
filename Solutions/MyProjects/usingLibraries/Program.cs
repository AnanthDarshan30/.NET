using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using MyLibrary;
using MathLibrary;
namespace usingLibraries
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Calculator obj = new Calculator();
            obj.add(45, 67);
            Console.ReadLine();
        }
    }
}
