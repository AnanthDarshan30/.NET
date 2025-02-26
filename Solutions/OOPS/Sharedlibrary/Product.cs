using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharedlibrary
{
    public class Product
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }
        public decimal Price { get; set; }
        public virtual string Display()
        {
            return ($"Product name = {this.Name} \n Description :- {this.Description} \n Product id = #{this.Id}\n Product Price = {this.Price} ");
        }
        public void Display(Product product)//Use case??
        {
            if (product == null)
            {
                throw new ArgumentException("The provided product is null or doesn't exist");
            }
            Console.WriteLine($"Product name = {product.Name} \n Description :- {product.Description} \n Product id = #{product.Id}\n Product Price = {product.Price}");
        }
        
    }
}