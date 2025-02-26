using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericDemo
{
    public class GenericConstraints<T, U> where T : class, new() where U : struct
    {
        public T GenericObject  { get; private set; }
        public U Value { get; private set; }   

        public GenericConstraints()
        {
            GenericObject = new T();
        }
        public void SetValue(U value)
        {
            Value = value;
        }
        public void CallTypeChecker() //Little bit of reflection is involved, Furthur read about reflection later
        {
            var method = typeof(T).GetMethod("TypeChecker");
            if (method != null)
            {
                var closedMethod = method.MakeGenericMethod(typeof(U));
                var result = closedMethod.Invoke(GenericObject, new object[] { Value });

                Console.WriteLine($"Returned from TypeChecker: {result}");
            }
            else
            {
                Console.WriteLine("TypeChecker method not found.");
            }
        }
        public void DisplayDetails()
        {
            Console.WriteLine($"Generic Object is of type : {typeof(T).Name}");
            Console.WriteLine($"Value is of type : {typeof(U).Name}, Value : {Value}");
        }

    }
}
