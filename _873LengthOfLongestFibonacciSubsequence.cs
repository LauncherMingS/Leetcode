using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    internal class _873LengthOfLongestFibonacciSubsequence
    {
        public void Test()
        {
            //Case 1
            int[] arr = [1, 2, 3, 4, 5, 6, 7, 8];
            Console.WriteLine(LenLongestFibSubseq(arr));

            //Case 2
            arr = [1, 3, 7, 11, 12, 14, 18];
            Console.WriteLine(LenLongestFibSubseq(arr));
        }
        public int LenLongestFibSubseq(int[] arr)
        {
            int n = arr.Length;
            Dictionary<int, int> indexDic = new Dictionary<int, int>();//arr[i] -> i
            int i;
            for (i = 0;i < n;i++)
            {
                indexDic[arr[i]] = i;
            }

            Dictionary<(int, int), int> dp = new Dictionary<(int, int), int>();
            int iValue;
            int currentLength;
            int maxLength = 0;
            for (int k = 2;k < n;k++)
            {
                for (int j = 1;j < k;j++)
                {
                    iValue = arr[k] - arr[j];
                    if (iValue < arr[j] && indexDic.ContainsKey(iValue))
                    {
                        i = indexDic[iValue];
                        currentLength = dp.GetValueOrDefault((i, j), 2) + 1;
                        dp[(j, k)] = currentLength;
                        maxLength = int.Max(maxLength, currentLength);
                    }
                }
            }

            return maxLength > 2 ? maxLength : 0;
        }
    }
}