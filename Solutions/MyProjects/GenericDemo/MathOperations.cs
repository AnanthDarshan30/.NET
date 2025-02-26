using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericDemo;
using System.Numerics;

namespace GenericDemo
{
    public class MathOperations<T> where T : INumber<T>
    {
        public T Add(T x, T y) => x + y;
    }
}
