using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LINQExample
{
    public class OrderBy
    {
        public static void OrderByFn(List<Employee> employees)
        {
            //Can use both IOrderedEnumerable or IEnumerable, as child objects are compatible with parent types.
            IEnumerable<Employee> SortedEmployees = employees.OrderBy(emp => emp.Job);

            Console.WriteLine(Environment.NewLine + "Employees after sorting: ");

            foreach (Employee emp in SortedEmployees)
            {
                Console.WriteLine($"Emp ID = {emp.EmpID}, Name = {emp.EmpName}, Job = {emp.Job}, City = {emp.City}");
            }
        }
        public static void OrderByThenBy(List<Employee> employees)
        {
            IEnumerable<Employee> SortedEmployees = employees.OrderBy(emp => emp.Job).ThenByDescending(emp => emp.EmpName);

            Console.WriteLine(Environment.NewLine + "Employees after sorting: ");

            foreach (Employee emp in SortedEmployees)
            {
                Console.WriteLine($"Emp ID = {emp.EmpID}, Name = {emp.EmpName}, Job = {emp.Job}, City = {emp.City}");
            }
        }
    }
}
