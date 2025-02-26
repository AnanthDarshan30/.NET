using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternMatching
{
    public class Program
    {
        static void Main(string[] args)
        {
            //referencing variable of parent class
            Parent pc = new Child();

            pc.ParentFn();

            if (pc is Child)
            {
                Child cc = (Child)pc;
                cc.ChildFn();
            }

            Console.WriteLine();

            if(pc is Child cc1)
            {
                cc1.ParentFn();
                cc1.ChildFn();
            }

            Console.ReadLine();
        }
    }
}
