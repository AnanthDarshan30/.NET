using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LINQExample
{
    public class Last
    {
        public static void LastFn(List<Employee> employees, string job)
        {
            Console.WriteLine();

            try
            {
                Employee LastEmployee = employees.Last(emp => emp.Job == job);
                Console.WriteLine($"Last Employee with the {job} is : {LastEmployee.EmpName} with ID: {LastEmployee.EmpID}");
            }
            catch (InvalidOperationException Ex)
            {
                Console.WriteLine("Given Job not found.");
            }

        }
        public static void LastOrDefaultFn(List<Employee> employees, string job)
        {
            Console.WriteLine();

            Employee LastEmployee = employees.LastOrDefault(emp => emp.Job == job);
            if (LastEmployee != null)
            {
                Console.WriteLine($"Last Employee with the {job} is: {LastEmployee.EmpName} with ID : {LastEmployee.EmpID}");
            }
            else
            {
                Console.WriteLine("No given job is found.");
            }
        }
        public Last()
        {
        }
    }
}
