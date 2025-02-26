using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Sharedlibrary;
namespace Polymorphism
{
    public class PhysicalProduct : Product
    {
        public double Weight { get; set; }
        public void SetProductDetails(string name, string description, decimal price, int id, double weight)
        {
            Name = name;
            Description = description;
            Price = price;
            Id = id;
            Weight = weight;
        }

        public new string Display()
        {
            return base.Display() + $", Weight: {Weight}kg";
        }
    }
}

