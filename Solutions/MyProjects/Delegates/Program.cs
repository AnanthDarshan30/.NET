using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Delegates;

namespace Delegates
{
    public class Program
    {
        static void Main(string[] args)
        {
            Methods method = new Methods();
            MyDelegateType myDelegate = new MyDelegateType(method.Add);
            // or can do by just declaring and initializing by myDelegate = method.Add;
            myDelegate += method.Subtract;


            Delegate[] delegateList = myDelegate.GetInvocationList();

            foreach (var item in delegateList)
            {
                Console.WriteLine(item.DynamicInvoke(30, 40));
            }

            //Console.WriteLine(myDelegate.Invoke(30,40));  

            Console.ReadLine();
        }
    }
}
