using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    internal class _1800MaximumAscendingSubarraySum
    {
        public void Test()
        {
            //Case 1
            int[] nums = [10, 20, 30, 5, 10, 50];
            Console.WriteLine(MaxAscendingSum(nums));

            //Case 2
            nums = [10, 20, 30, 40, 50];
            Console.WriteLine(MaxAscendingSum(nums));

            //Case 3
            nums = [12, 17, 15, 13, 10, 11, 12];
            Console.WriteLine(MaxAscendingSum(nums));
        }
        public int MaxAscendingSum(int[] nums)
        {
            int n = nums.Length;
            int maxSum = 0;
            int sum = nums[0];
            for (int i = 1;i < n;i++)
            {
                if (nums[i] > nums[i - 1])
                {
                    sum += nums[i];
                }
                else
                {
                    maxSum = Math.Max(maxSum, sum);
                    sum = nums[i];
                }
            }

            return Math.Max(maxSum, sum);
        }
    }
}
