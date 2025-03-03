using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Leetcode.Program;

namespace Leetcode
{
    internal class _2161PartitionArrayAccordingToGivenPivot
    {
        public void Test()
        {
            //Case 1
            int[] nums = [9, 12, 5, 10, 14, 3, 10];
            int pivot = 10;
            PrintArray(PivotArray(nums, pivot));

            //Case 2
            nums = [-3, 4, 3, 2];
            pivot = 2;
            PrintArray(PivotArray(nums, pivot));
        }
        public int[] PivotArray(int[] nums, int pivot)
        {
            int n = nums.Length;
            int[] newArray = new int[n];
            int lessThanPivotIndex = 0;
            int greaterThanPivotIndex = n - 1;
            for (int i = 0, j = n - 1; i < n; i++, j--)
            {
                if (nums[i] < pivot)
                {
                    newArray[lessThanPivotIndex] = nums[i];
                    lessThanPivotIndex++;
                }
                if (nums[j] > pivot)
                {
                    newArray[greaterThanPivotIndex] = nums[j];
                    greaterThanPivotIndex--;
                }
            }

            while (lessThanPivotIndex <= greaterThanPivotIndex)
            {
                newArray[lessThanPivotIndex] = pivot;
                lessThanPivotIndex++;
            }

            return newArray;
        }
    }
}