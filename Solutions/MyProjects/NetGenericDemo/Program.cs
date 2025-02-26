using System;

namespace StringCollectionApp 
{
    public class StringCollection
    {
        private string[] _strings = new string[5]; 
        public string this[int index]
        {
            get
            {
                // Validate index for getting value
                if (index < 0 || index >= _strings.Length)
                    throw new IndexOutOfRangeException("Index out of range.");
                return _strings[index];
            }
            set
            {
                // Validate index for setting value
                if (index < 0 || index >= _strings.Length)
                    throw new IndexOutOfRangeException("Index out of range.");
                _strings[index] = value;
            }
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            var stringCollection = new StringCollection(); 
            stringCollection[0] = "Hello"; 
            stringCollection[1] = "World"; 

            
            Console.WriteLine(stringCollection[0]); 
            Console.WriteLine(stringCollection[1]); 

            Console.ReadLine(); 
        }
    }
}
