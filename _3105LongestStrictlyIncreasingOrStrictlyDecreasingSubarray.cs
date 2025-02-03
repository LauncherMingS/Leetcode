using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    internal class _3105LongestStrictlyIncreasingOrStrictlyDecreasingSubarray
    {
        public void Test()
        {
            //Case 1
            int[] nums = [1, 4, 3, 3, 2];
            Console.WriteLine(LongestMonotonicSubarray(nums));

            //Case 2
            nums = [3, 3, 3, 3];
            Console.WriteLine(LongestMonotonicSubarray(nums));

            //Case 3
            nums = [3, 2, 1];
            Console.WriteLine(LongestMonotonicSubarray(nums));
        }
        public int LongestMonotonicSubarray(int[] nums)
        {
            int n = nums.Length;
            int flag = 0;

            int longestLength = 1;
            int count = 0;
            for (int i = 1;i < n;i++)
            {
                if (nums[i] > nums[i - 1])
                {
                    if (flag != 1)
                    {
                        longestLength = Math.Max(longestLength, count);
                        flag = 1;
                        count = 2;
                    }
                    else
                    {
                        count++;
                    }
                }
                else if (nums[i] < nums[i - 1])
                {
                    if (flag != 2)
                    {
                        longestLength = Math.Max(longestLength, count);
                        flag = 2;
                        count = 2;
                    }
                    else
                    {
                        count++;
                    }
                }
                else
                {
                    longestLength = Math.Max(longestLength, count);
                    count = flag = 0;
                }
            }

            return Math.Max(longestLength, count);
        }
    }
}