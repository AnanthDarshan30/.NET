using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_MethodImplementation_
{
    internal class Laptop : Default
    {
        public int Id { get; private set; }
        public override void Display()
        {
            Console.WriteLine($"this is a laptop with Id #{Id}");
        }
        public void SetId(int id)
        {
            Id = id;
        }
    }
}
