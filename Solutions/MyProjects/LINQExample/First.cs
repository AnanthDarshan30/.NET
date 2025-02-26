using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LINQExample
{
    public class First
    {
        public static void FirstFn(List<Employee> employees, string job)
        {
            Console.WriteLine();

            try
            {
                Employee firstEmployee = employees.First(emp => emp.Job == job);
                Console.WriteLine($"First Employee with the {job} is : {firstEmployee.EmpName} with ID: {firstEmployee.EmpID}");
            }
            catch (InvalidOperationException Ex)
            {
                Console.WriteLine("Given Job not found.");
            }

        }
        public static void FirstOrDefaultFn(List<Employee> employees, string job)
        {
            Console.WriteLine() ;

            Employee firstEmployee = employees.FirstOrDefault(emp => emp.Job == job);
            if (firstEmployee != null)
            {
                Console.WriteLine($"First Employee with the {job} is: {firstEmployee.EmpName} with ID : {firstEmployee.EmpID}");
            }
            else
            {
                Console.WriteLine("No given job is found.");
            }
        }
        public First()
        {
        }
    }
}
