using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sharedlibrary;

namespace Inheritance
{
    public class DigitalProduct : Product
    {
        public string FileSize { get; set; }

        public DigitalProduct(string fileSize)
        {
            FileSize = fileSize;
        }
        public void SetProductDetails(string name, string description, decimal price, int id)
        {
            Name = name;
            Description = description;
            Price = price;
            Id = id;
        }
        public new string Display()
        {
            return base.Display() + $", File Size: {FileSize}";
        }
    }
}
