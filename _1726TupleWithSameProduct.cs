using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    internal class _1726TupleWithSameProduct
    {
        public void Test()
        {
            //Case 1
            int[] nums = [2, 3, 4, 6];
            Console.WriteLine(TupleSameProduct(nums));

            //Case 2
            nums = [1, 2, 4, 5, 10];
            Console.WriteLine(TupleSameProduct(nums));
        }
        public int TupleSameProduct(int[] nums)
        {
            Dictionary<int, int> productCount = new Dictionary<int, int>();
            int result = 0;

            int n = nums.Length;
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    int product = nums[i] * nums[j];

                    if (productCount.ContainsKey(product))
                    {
                        result += (productCount[product] * 8);
                        productCount[product]++;
                    }
                    else
                    {
                        productCount.Add(product, 1);
                    }
                }
            }

            return result;
        }
    }
}
