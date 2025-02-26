using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invariant
{
    internal class Program
    {
        static void Main()
        {
            double number = 12345.67;

            // French
            CultureInfo.CurrentCulture = new CultureInfo("fr-FR");

            string formattedNumber = number.ToString(); 
            Console.WriteLine(formattedNumber); 

            // Using Invariant Culture
            string invariantFormattedNumber = number.ToString(CultureInfo.InvariantCulture);
            Console.WriteLine(invariantFormattedNumber); 

            Console.ReadLine();
        }
    }
}
