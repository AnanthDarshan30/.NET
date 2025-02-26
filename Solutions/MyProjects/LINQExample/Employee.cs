using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LINQExample
{
    public class Employee
    {
        public int EmpID { get; set; } 
        public string EmpName { get; set; }
        public string Job {  get; set; }
        public string City { get; set; }    
        public int Salary { get; set; }
        public Employee()
        {
        }
    }
}
