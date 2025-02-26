using Sharedlibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Abstraction
{
    public abstract class Product
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }
        public decimal Price { get; set; }

        // Abstract method must be overridden in derived classes
        public abstract string Display();
    }
}

