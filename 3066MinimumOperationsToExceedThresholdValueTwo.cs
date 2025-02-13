using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    internal class _3066MinimumOperationsToExceedThresholdValueTwo
    {
        public void Test()
        {
            //Case 1
            int[] nums = [2, 11, 10, 1, 3];
            int k = 10;
            Console.WriteLine(MinOperations(nums, k));

            //Case 2
            nums = [1, 1, 2, 4, 9];
            k = 20;
            Console.WriteLine(MinOperations(nums, k));

            //Case 3
            nums = [1000000000, 999999999, 1000000000, 999999999, 1000000000, 999999999];
            k = 1000000000;
            Console.WriteLine(MinOperations(nums, k));
        }
        public int MinOperations(int[] nums, int k)
        {
            int n = nums.Length;

            PriorityQueue<int, int> queue = new PriorityQueue<int, int>(n);
            //1. represent the element of array given
            //2  result of calculate min(x, y) * 2 + max(x, y)
            int num;
            for (int i = 0; i < nums.Length; i++)
            {
                num = nums[i];
                if (num < k)
                {
                    queue.Enqueue(num, num);
                }
            }

            int operationCount = 0;
            while (queue.Count > 1)
            {
                num = (queue.Dequeue() * 2) + queue.Dequeue();//int, may overflow
                if (num < k && num > 0)
                {
                    queue.Enqueue(num, num);
                }

                operationCount++;
            }

            return operationCount + queue.Count;
        }
    }
}