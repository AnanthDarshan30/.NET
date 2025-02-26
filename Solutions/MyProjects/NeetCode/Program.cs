using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using NeetCode;
// using System.Security.Cryptography.X509Certificates;

namespace NeetCode
{
    public partial class Solution
    {
        public bool hasDuplicate(int[] nums)
        {
            List<int> count = new List<int>();
            foreach (int i in nums)
            {
                if (count.Contains(i))
                {
                    return false;
                }
                else
                {
                    count.Add(i);
                }
            }
            return true;
        }
        public bool IsAnagram(ref string s, ref string t)
        {
            if (!s.Length.Equals(t.Length)) return false;
            int[] count = new int[26];
            foreach (var  val in s)
            {
                count[val - 'a']++;
            }
            foreach(var val in t)
            {
                count[val-'a']--;
            }
            foreach(int val in count)
            {
                if (val != 0) return false;
            }
            return true;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution obj = new Solution();
            //Code for reverseing the string:


            //Console.Write("Enter the elements of the array: ");
            //string input = Console.ReadLine();
            //string[] numsString = input.Split(' ');
            //int[] nums = new int[numsString.Length];
            //for (int i = 0; i < numsString.Length; i++)
            //{
            //    nums[i] = Convert.ToInt32(numsString[i]);
            //}
            //bool result = obj.hasDuplicate(nums);
            //if (!result)
            //{
            //    Console.WriteLine("Array Contains Duplicates.");
            //}
            //else
            //{
            //    Console.WriteLine("Array Does not Contain Duplicates.");
            //}



            ////Code for checking if two strings are anagram or not.

            //Console.Write("Enter the 1st String: ");
            //string s = Console.ReadLine().ToLower();
            //Console.Write("Enter the 2nd String: ");
            //string t = Console.ReadLine().ToLower();
            //bool result = obj.IsAnagram(ref s, ref t);
            //if (result)
            //{
            //    Console.WriteLine("Given strings are Anagrams to each other");
            //}
            //else { Console.WriteLine("Given strings are NOT Anagrams to each other"); }

            //Code for Two Sum
            //Console.Write("Enter the elements of the array: ");
            //string input = Console.ReadLine();
            //string[] numsString = input.Split(' ');
            //int[] nums = new int[numsString.Length];
            //for (int i = 0; i < numsString.Length; i++)
            //{
            //    nums[i] = Convert.ToInt32(numsString[i]);
            //}
            //Console.Write("Enter the target Element: ");
            //int.TryParse(Console.ReadLine(), out int target);
            //int[] result = obj.TwoSum(nums, target);
            //Console.WriteLine($"Indices whose sum equals the target is {result[0]} and {result[1]}.");


            //Code for Vald Parenthesis

            Console.Write($"Enter the string: ");
            string s = Console.ReadLine();
            bool result = obj.IsValid(s);

            if (result)
            {
                Console.WriteLine("Given string contains valid Parenthesis.");
            }
            else
            {
                Console.WriteLine("Given string contains valid Parenthesis.");
            }


            
            Console.ReadLine();
        }
    }

}
