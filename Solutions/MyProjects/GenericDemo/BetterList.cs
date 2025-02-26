using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericDemo
{
    public class BetterList<T>
    {
        private List<T> list = new List<T>();
        public void AddToList(T value)
        {
            list.Add(value);
            Console.WriteLine($"{value} has been added to the list.");
        }
    }
}
