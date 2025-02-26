using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_MethodImplementation_
{
    internal class Default: IProduct
    {
        public int Id { get; private set; }

        public virtual void Display()
        {
            Console.WriteLine("This is a default Display");
        }
        public virtual void UpdateId(int id)
        {
            Id = id;
        }
    }
}
