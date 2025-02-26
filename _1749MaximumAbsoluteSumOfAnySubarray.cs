using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    internal class _1749MaximumAbsoluteSumOfAnySubarray
    {
        public void Test()
        {
            //Case 1
            int[] nums = [1, -3, 2, 3, -4];
            Console.WriteLine(MaxAbsoluteSum(nums));

            //Case 2
            nums = [2, -5, 1, -4, 3, -2];
            Console.WriteLine(MaxAbsoluteSum(nums));
        }
        public int MaxAbsoluteSum(int[] nums)
        {
            int maxSum;
            int minSum;
            int currentPositiveSum;
            int currentNegativeSum;
            currentNegativeSum = currentPositiveSum = minSum = maxSum = nums[0];

            for (int i = 1, num; i < nums.Length; i++)
            {
                num = nums[i];

                currentPositiveSum = int.Max(num, currentPositiveSum + num);
                maxSum = int.Max(maxSum, currentPositiveSum);

                currentNegativeSum = int.Min(num, currentNegativeSum + num);
                minSum = int.Min(minSum, currentNegativeSum);
            }

            return int.Max(maxSum, int.Abs(minSum));
        }
    }
}