using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace StringsAlgo
{
    internal class Program
    {

        static string NormalizeString(String input)
        {
            string lowercased = input.ToLower();
            string trimmed = lowercased.Trim();
            return trimmed.Replace(",", "");
        }
        static Boolean IsUpperCase(string s)
        {
            return s.All(c=> c==' ' || char.IsUpper(c));
        }
        static Boolean IsLowerCase(string s)
        {
            return s.All(c => c == ' ' || char.IsLower(c));
        }
        static Boolean IsPasswordComplex(string s)
        {
            return s.Any(char.IsDigit) && s.Any(char.IsLower) && s.Any(char.IsUpper);
        }

        static String Reverse(String input)
        {
            if (string.IsNullOrEmpty(input)) return input;
            StringBuilder reverse = new StringBuilder(input.Length);

            for(int i = input.Length-1; i >=0; i--)
            {
                reverse.Append(input[i]);
            }
            return reverse.ToString();

        }
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Choose the function you want to perform and enter it's allocated number:\n" +
                    "1)Check for lower case.\n" +
                    "2)Check for upper case.\n" +
                    "3)Check if Password you enter is strong or not.\n" +
                    "4)Normalize a given string.\n" +
                    "5)Reverse a given string\n" +
                    "6)exit.");
                bool check = int.TryParse(Console.ReadLine(), out int num);
                if (!check)
                {
                    Console.WriteLine("Please enter a number.");
                    continue;
                }
                switch (num)
                {
                    case 1:
                        Console.WriteLine("Enter a string to check for lower case:");
                        Console.WriteLine(IsLowerCase(Console.ReadLine()));
                        break;
                    case 2:
                        Console.WriteLine("Enter a string to check for upper case:");
                        Console.WriteLine(IsUpperCase(Console.ReadLine()));
                        break;
                    case 3:
                        Console.WriteLine("Enter a password to check if it's string or not:");
                        Console.WriteLine("Password is strong: "+IsPasswordComplex(Console.ReadLine()));
                        break;
                    case 4:
                        Console.Write("Give a string to normalize: ");
                        Console.WriteLine(NormalizeString(Console.ReadLine()));
                        break;
                    case 5:
                        Console.Write("Enter a string to reverse:");
                        Console.WriteLine($"String after reversing is:{Reverse(Console.ReadLine())}.");
                        break;
                    case 6:
                        return;
                    default:
                        Console.WriteLine("please enter a valid number.");
                        break;
                }

            }
        }
    }
}
