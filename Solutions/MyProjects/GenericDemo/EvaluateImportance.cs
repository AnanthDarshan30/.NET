using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericDemo;

namespace GenericDemo
{
    public class EvaluateImportance : IImportance<int>, IImportance<string>
    {
        public int MostImportant(int a, int b)
        {
            if (a > b)
            {
                return a;
            }
            else
            {
                return b;
            }
        }
        public string MostImportant(string a, string b)
        {
            if (a.Length > b.Length)
            {
                return a;
            }
            else
            {
                return b;
            }
        }
    }
}
