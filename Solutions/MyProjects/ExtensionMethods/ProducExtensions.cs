using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ExtensionLIbrary;

namespace ExtensionMethods
{
    public static class ProducExtensions
    {
        public static double GetDiscount(this Product product)
        {
            return product.ProductCost * product.DiscountPercentage / 100;
        }
    }
}
