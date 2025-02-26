using System;
using System.Collections.Generic;
using Inheritance;
using Polymorphism;
using Encapsulation;
using Abstraction;
using Sharedlibrary;

namespace ClassesAndObjects
{
    public class Program
    {
        static void Main(string[] args)
        {
           
            Product laptop = new Product
            {
                Name = "Laptop",
                Description = "High-performance laptop",
                Price = 89999.00m,
                Id = 001
            };

           
            DigitalProduct ebook = new DigitalProduct("500MB");
            ebook.SetProductDetails("E-Book", "Digital book", 1999.00m, 004);

            
            PhysicalProduct monitor = new PhysicalProduct();
            monitor.SetProductDetails("Monitor", "4K Monitor", 25999.00m, 005, 5.5);

           
            Customer customer = new Customer("Ananth", "ananth.darshan@gmail.com");
            SecureOrder secureOrder = new SecureOrder();
            secureOrder.SetOrderDetails(1, customer);
            secureOrder.AddProduct(laptop);
            secureOrder.AddProduct(monitor);

           
            DiscountedProduct discountedProduct = new DiscountedProduct();
            discountedProduct.SetProductDetails("Headphones", "Noise-cancelling headphones", 4999.00m, 006);
            discountedProduct.ApplyDiscount(10);

          
            Console.WriteLine("Your ordered products are:");
            Console.WriteLine(laptop.Display());
            Console.WriteLine(ebook.Display());   
            Console.WriteLine(monitor.Display());  
            Console.WriteLine(discountedProduct.Display()); 
            
            Console.WriteLine($"Order Details: {secureOrder.GetOrderDetails()}");
            Console.WriteLine($"Total Order Cost: {secureOrder.CalculateTotal():C}");
            Console.ReadLine();
        }
    }
}

