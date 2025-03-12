using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    internal class _2529MaximumCountOfPostiveIntegerAndNegativeInteger
    {
        public void Test()
        {
            //Case 1
            int[] nums = [-2, -1, -1, 1, 2, 3];
            Console.WriteLine(MaximumCount(nums));

            //Case 2
            nums = [-3, -2, -1, 0, 0, 1, 2];
            Console.WriteLine(MaximumCount(nums));

            //Case 3
            nums = [5, 20, 66, 1314];
            Console.WriteLine(MaximumCount(nums));
        }

        //Binary Search
        int[] nums;
        int numsLength;

        public int MaximumCount(int[] nums)
        {
            this.nums = nums;
            this.numsLength = nums.Length;

            int positiveCount = numsLength - FindLowestBound(1);
            int negativeCount = FindLowestBound(0);

            return int.Max(positiveCount, negativeCount);
        }

        public int FindLowestBound(int target)
        {
            int leftPointer = 0;
            int rightPointer = numsLength - 1;
            int midPointer;
            while (leftPointer <= rightPointer)
            {
                midPointer = leftPointer + ((rightPointer - leftPointer) / 2);
                if (nums[midPointer] < target)
                {
                    leftPointer = midPointer + 1;
                }
                else
                {
                    rightPointer = midPointer - 1;
                }
            }

            return leftPointer;
        }

        //Burte Force
        //public int MaximumCount(int[] nums)
        //{
        //    int positiveCount = 0;
        //    int negativeCount = 0;
        //    int numsLength = nums.Length;
        //    for (int i = 0; i < numsLength; i++)
        //    {
        //        if (nums[i] > 0)
        //        {
        //            positiveCount++;
        //        }
        //        else if (nums[i] < 0)
        //        {
        //            negativeCount++;
        //        }
        //    }

        //    return int.Max(positiveCount, negativeCount);
        //}
    }
}