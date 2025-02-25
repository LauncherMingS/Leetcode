using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    internal class _1524NumberOfSub_arraysWithOddSum
    {
        public void Test()
        {
            //Case 1
            int[] arr = [1, 3, 5];
            Console.WriteLine(NumOfSubarrays(arr));

            //Case 2
            arr = [2, 4, 6];
            Console.WriteLine(NumOfSubarrays(arr));

            //Case 3
            arr = [1, 2, 3, 4, 5, 6, 7];
            Console.WriteLine(NumOfSubarrays(arr));
        }

        public int NumOfSubarrays(int[] arr)
        {
            int n = arr.Length;
            int odd = 0;
            int sum = 0;

            for (int i = 0; i < n; i++)
            {
                sum += arr[i];
                odd += (sum & 1);
            }

            int even = n - odd;
            return (int)((1L * even * odd + odd) % 1_000_000_007);
        }

        //public int NumOfSubarrays(int[] arr)
        //{
        //    const int MOD = 1_000_000_007;
        //    int n = arr.Length;
        //    int oddCount = 0;
        //    int evenCount = 1;
        //    int prefixSum = 0;
        //    int count = 0;

        //    for (int i = 0; i < n; i++)
        //    {
        //        prefixSum += arr[i];

        //        if ((prefixSum & 1) == 1)
        //        {
        //            count = (count + evenCount) % MOD;
        //            oddCount++;
        //        }
        //        else
        //        {
        //            count = (count + oddCount) % MOD;
        //            evenCount++;
        //        }
        //    }

        //    return count;
        //}
    }
}