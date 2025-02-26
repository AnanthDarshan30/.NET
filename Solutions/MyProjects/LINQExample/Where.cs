using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LINQExample
{
    public class Where
    {
        public static void WhereFn(List<Employee> employees)
        {
            IEnumerable<Employee> result = employees.Where(emp => emp.Job == "Developer");
            //List<Employee> res = result.ToList();

            Console.WriteLine("Employees whose job is a developer:");
            foreach (Employee emp in result)
            {
                Console.WriteLine($"Emp ID = {emp.EmpID}, Name = {emp.EmpName}, Job = {emp.Job}, City = {emp.City}");
            }
        }
    }
}
