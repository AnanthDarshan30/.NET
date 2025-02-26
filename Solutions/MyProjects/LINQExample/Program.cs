using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LINQExample
{ 
    public class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>()
            {
                new Employee(){EmpID = 01, EmpName = "SRK", Job = "Podcast Speaker", City="New York", Salary = 100000},
                new Employee(){EmpID = 02, EmpName = "Dino", Job = "Developer", City = "London", Salary = 200000},
                new Employee(){EmpID = 03, EmpName = "Anushka", Job = "Manager", City = "California", Salary = 500000},
                new Employee(){EmpID = 04, EmpName = "Ananth", Job = "Developer", City = "Tokyo", Salary = 4000040},
                new Employee(){EmpID = 04, EmpName = "ChatGPT", Job = "Manager", City = "New York", Salary = 6403460}
            };

            Where.WhereFn(employees);
            
            OrderBy.OrderByFn(employees);

            OrderBy.OrderByThenBy(employees);

            Console.WriteLine("First and FirstOrDefault functions: ");

            First.FirstFn(employees, "Clerk");

            First.FirstFn(employees, "Developer");

            First.FirstOrDefaultFn(employees, "Clerk");

            First.FirstOrDefaultFn(employees, "Manager");

            Console.WriteLine("Last and LastOrDefault functions: ");

            Last.LastFn(employees, "Clerk");

            Last.LastFn(employees, "Developer");

            Last.LastOrDefaultFn(employees, "Clerk");

            Last.LastOrDefaultFn(employees, "Manager");

            IEnumerable<Employee> employeeNewYork = from emp in employees
                                             where emp.City == "New York"
                                             select emp;
            List<Employee> NewYorkEmp = employeeNewYork.ToList();

            var groupedEmployees = from emp in employees
                                   group emp by emp.City into cityGroup
                                   select new
                                   {
                                       City = cityGroup.Key,
                                       Employees = cityGroup.ToList(),
                                       EmployeeCount = cityGroup.Count()
                                   };
            foreach (var group in groupedEmployees)
            {
                Console.WriteLine($"City : {group.City}");
                foreach (var employee in group.Employees)
                {
                    Console.WriteLine($" - {employee.EmpName}");
                }
            }

            Console.WriteLine("Employes from New york are : ");
            foreach (Employee emp in NewYorkEmp)
            {
                Console.WriteLine($"    - {emp.EmpName}");
            }




            Console.ReadLine();
        }
    }
}