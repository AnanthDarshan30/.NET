using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeC_
{
    public class PhysicalCustomer : ICustomer
    {
        public string Name { get;private set; }
        public int ID { get; private set; }
        public PhysicalCustomer(string name, int id) 
        {
            Name = name;
            ID = id;
        }
        void ICustomer.Details()
        {
            Console.WriteLine($"your name is {Name} and your id is {ID}");
        }
        public void ShowDetails()
        {
            ((ICustomer)this).Details();
        }
    }
}
