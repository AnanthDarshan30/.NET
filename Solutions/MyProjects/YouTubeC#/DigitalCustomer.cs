using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeC_
{
    public class DigitalCustomer : ICustomer
    {
        public string Name { get; private set; }
        public int ID { get; private set; }
        public DigitalCustomer (string name, int id)
        {
            Name = name;
            ID = id;
        }
        public void ChangeName(string newName)
        {
            Name = newName;
        }
        public void Details()
        {
            Console.WriteLine($"Your name is {Name} your ID is {ID}.");
        }
    }
}
