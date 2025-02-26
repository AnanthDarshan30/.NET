using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCode
{
    public partial class Solution
    {
        public int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> indices = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                var diff = target - nums[i];
                if (indices.ContainsKey(diff))
                {
                    return new int[] { indices[diff], i };
                }
                indices[nums[i]] = i;
            }
            return null;
        }
        public bool IsValid(string s)
        {
            var stack = new Stack<char>();
            var pairs = new Dictionary<char, char>()
            {
                [')'] = '(',
                [']'] = '[',
                ['}'] = '{'
            };

            foreach (char c in s)
            {
                if (!pairs.ContainsKey(c))
                {
                    stack.Push(c);
                }
                else if (stack.Count == 0 || stack.Pop() != pairs[c])
                {
                    return false;
                }
            }

            return stack.Count == 0;
        }
    }
}
