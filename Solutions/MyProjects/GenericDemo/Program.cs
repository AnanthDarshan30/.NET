using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using GenericDemo;

namespace GenericDemo
{
    public class GenericClass
    {
        public T TypeChecker<T>(T value)
        {
            Console.WriteLine($"Type = {typeof(T)}");
            Console.WriteLine($"Value = {value}");
            return value;
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            //Basic Generic Method.
            GenericClass genericClass = new GenericClass();
            genericClass.TypeChecker("Hello");
            genericClass.TypeChecker(53.634F);
            
            //Example 1 - int type
            BetterList<int> betterNumbers = new BetterList<int>();
            betterNumbers.AddToList(5);

            object[] objects = new object[5];
            for(int i = 0;i<5;i++)
            {
                objects[i] = $"object[{i}]";
            }

            //Example 2 - objects
            BetterList<object> obj = new BetterList<object>();
            obj.AddToList(objects);
            foreach (var item in objects)
            {
                Console.WriteLine(item);
            }

            //Interface
            EvaluateImportance imp = new EvaluateImportance();
            Console.WriteLine($"The Greater value between the two numbers is {imp.MostImportant(5, 6)}");

            //Generic Constraints
            GenericConstraints<GenericClass, int> val = new GenericConstraints<GenericClass, int>();
            val.SetValue(100);
            val.CallTypeChecker();
            val.DisplayDetails();

            Console.ReadLine();
        }
    }
}
