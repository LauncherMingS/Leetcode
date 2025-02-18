using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    internal class _2375ConstructSmallestNumberFromDIString
    {
        public void Test()
        {
            //Case 1
            string pattern = "IIIDIDDD";
            Console.WriteLine(SmallestNumber(pattern));

            //Case 2
            pattern = "DDD";
            Console.WriteLine(SmallestNumber(pattern));

            //Case 3
            pattern = "DDDIII";
            Console.WriteLine(SmallestNumber(pattern));
        }

        //public string SmallestNumber(string pattern)
        //{
        //    int n = pattern.Length;
        //    Stack<int> stack = new Stack<int>();
        //    StringBuilder sb = new StringBuilder();

        //    for (int i = 0; i <= n; i++)
        //    {
        //        stack.Push(i + 1);
        //        if (i == n || pattern[i] == 'I')
        //        {
        //            while (stack.Count > 0)
        //            {
        //                sb.Append(stack.Pop());
        //            }
        //        }
        //    }

        //    return sb.ToString();
        //}

        public string SmallestNumber(string pattern)
        {
            int patternLength = pattern.Length;
            int numLength = patternLength + 1;
            int[] nums = new int[numLength];
            int lastIndex = 0;
            int lastNum = 0;
            for (int i = 1, j; i < numLength; i++)
            {
                j = i - 1;
                if (pattern[j] == 'I')
                {
                    nums[i] = lastNum + 1;
                    lastIndex = i;
                    lastNum = Math.Max(lastNum, nums[i]);
                }
                else if ((i < patternLength && pattern[i] == 'I') || i == numLength - 1)
                {
                    nums[i] = lastNum;
                    j = i;
                    while (--j >= lastIndex)
                    {
                        nums[j] = nums[j + 1] + 1;
                    }
                    lastNum = nums[j + 1];
                }
            }

            char[] results = new char[numLength];
            for (int i = 0; i < numLength; i++)
            {
                results[i] = (char)('1' + nums[i]);
            }
            StringBuilder sb = new StringBuilder();
            return new string(results);
        }
    }
}