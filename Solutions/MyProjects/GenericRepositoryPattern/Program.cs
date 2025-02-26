using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericRepositoryPattern;

namespace GenericRepositoryPattern
{
    public class Program
    {
        public static void Main()
        {
            //Repos creation
            var productRepository = new Repository<Product>();
            var customerRepository = new Repository<Customer>();

            //Services Creation
            var productService = new ProductService(productRepository);
            var customerService = new CustomerService(customerRepository);

            // Adding products
            productService.AddProduct(new Product { Id = 1, Name = "Laptop", Price = 1000 });
            productService.AddProduct(new Product { Id = 2, Name = "Smartphone", Price = 600 });

            // Adding customers
            customerService.AddCustomer(new Customer { Id = 1, FullName = "Shiva Ramaswamy", Email = "shiva@example.com" });
            customerService.AddCustomer(new Customer { Id = 2, FullName = "Dinesh Golconda", Email = "dinesh@example.com" });

            //Displaying products
            Console.WriteLine("Products:");
            foreach (var product in productService.GetAllProducts())
            {
                Console.WriteLine($"{product.Id}: {product.Name} - ₹{product.Price}");
            }

            //Displaying customers
            Console.WriteLine("\nCustomers:");
            foreach (var customer in customerService.GetAllCustomers())
            {
                Console.WriteLine($"{customer.Id}: {customer.FullName} - {customer.Email}");
            }

            Console.ReadLine();
        }
    }
}
