using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    internal class _1980FindUniqueBinaryString
    {
        public void Test()
        {
            //Case 1
            string[] nums = ["01", "10"];
            Console.WriteLine(FindDifferentBinaryString(nums));

            //Case 2
            nums = ["00", "01"];
            Console.WriteLine(FindDifferentBinaryString(nums));

            //Case 3
            nums = ["111", "011", "001"];
            Console.WriteLine(FindDifferentBinaryString(nums));
        }

        public string FindDifferentBinaryString(string[] nums)
        {
            int n = nums.Length;
            char[] binaryNum = new char[n];
            char bit;
            for (int i = 0; i < n; i++)
            {
                bit = nums[i][i];
                binaryNum[i] = (bit == '0') ? '1' : '0';
            }

            return new string(binaryNum);
        }

        //public string FindDifferentBinaryString(string[] nums)
        //{
        //    int n = nums.Length;
        //    int bitSize = 1 << n;
        //    bool[] isContains = new bool[bitSize];
        //    for (int i = 0; i < n; i++)
        //    {
        //        isContains[Convert.ToInt32(nums[i], 2)] = true;
        //    }

        //    for (int i = bitSize - 1; i >= 0; i--)
        //    {
        //        if (!isContains[i])
        //        {
        //            ReadOnlySpan<char> num = Convert.ToString(i, 2).AsSpan();
        //            bitSize = num.Length;
        //            if (num.Length != n)
        //            {
        //                char[] binaryNum = new char[n];
        //                i = 1;
        //                while (i <= bitSize)
        //                {
        //                    binaryNum[^i] = num[^i];
        //                    i++;
        //                }
        //                while (i <= n)
        //                {
        //                    binaryNum[^i] = '0';
        //                    i++;
        //                }
        //                return new string(binaryNum);
        //            }
        //            else
        //            {
        //                return num.ToString();
        //            }
        //        }
        //    }

        //    return string.Empty;
        //}
    }
}