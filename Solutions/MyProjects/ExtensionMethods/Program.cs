using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExtensionLIbrary;

namespace ExtensionMethods
{
    public class Program
    {
        static void Main(string[] args)
        {
            //creating object
            Product p = new Product() { ProductCost = 1000, DiscountPercentage = 10 };
            Console.Write("The discounted price is: ");
            Console.WriteLine(p.GetDiscount());


            string paragraph = "this is an example sentence, check it. i want to correct this the grammatical way. check it.";
            string result = paragraph.ToParaCase();

            Console.WriteLine(result);

            Console.ReadLine();
        }
    }
}
