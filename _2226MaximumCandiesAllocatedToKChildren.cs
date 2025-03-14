using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    internal class _2226MaximumCandiesAllocatedToKChildren
    {
        public void Test()
        {
            //Case 1
            int[] candies = [5, 8, 6];
            int k = 3;
            Console.WriteLine(MaximumCandies(candies, k));

            //Case 2
            candies = [2, 5];
            k = 11;
            Console.WriteLine(MaximumCandies(candies, k));

            //Case 3
            candies = [4, 7, 5];
            k = 16;
            Console.WriteLine(MaximumCandies(candies, k));

            //Case 4
            candies = [162, 343, 511, 240, 578, 497, 762, 720, 714, 158, 535, 529, 652, 564, 703, 814, 408, 154, 659, 673, 857, 760, 989, 310, 834, 804, 577, 115, 510, 108, 612, 466, 310, 461, 573, 500, 116, 324, 934, 442, 399, 990, 992, 215, 947, 522, 835, 762, 918, 548, 684, 938, 680, 125, 880, 272, 807, 673, 768, 111, 854, 768, 910, 509, 477, 932, 941, 795, 504, 821, 222, 739, 282, 207, 659, 768, 213, 574, 405, 984, 639, 132, 596, 255, 369, 129, 605, 265, 323, 534, 763, 575, 323, 187, 605, 874, 384, 432, 925, 191];
            k = 22;
            Console.WriteLine(MaximumCandies(candies, k));
        }
        public int MaximumCandies(int[] candies, long k)
        {
            int candiesLength = candies.Length;
            long maxCandies = 0;
            for (int i = 0; i < candiesLength; i++)
            {
                maxCandies += candies[i];
            }
            if (maxCandies < k)
            {
                return 0;
            }
            if (maxCandies == k)
            {
                return 1;
            }
            maxCandies /= k;

            int left = 0;
            int right = (int)maxCandies;
            int mid = 0;
            int childrenCount;
            while (left < right)
            {
                mid = (left + right + 1) / 2;

                childrenCount = 0;
                for (int i = 0; i < candiesLength; i++)
                {
                    childrenCount += (candies[i] / mid);
                }

                if (childrenCount >= k)
                {
                    left = mid;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return left;
        }
    }
}