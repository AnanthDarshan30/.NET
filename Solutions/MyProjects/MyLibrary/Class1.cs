using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    public class Calculator
    {
        public void Add(int x, int y)
        {
            Console.WriteLine($"{x} + {y} = {x+y}");
        }
        public void Multiply(int x, int y)
        {
            Console.WriteLine($" {x} x {y} = {x*y}");
        }
    }
    public class Info
    {
        public int age;
        public string name;
        public void printInfo(string name, int age)
        {
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"age: {age}");
        }
    }
}
