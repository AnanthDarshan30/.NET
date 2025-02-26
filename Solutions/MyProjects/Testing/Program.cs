using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Testing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Test test = new Test();
            test.MyMethod();
            Console.ReadLine();
        }
    }
}
