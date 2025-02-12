using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Numerics;

namespace Leetcode
{
    internal class _2342MaxSumOfAPairWithEqualSumOfDigits
    {
        public void Test()
        {
            //Case 1
            int[] nums = [18, 43, 36, 13, 7];
            Console.WriteLine(MaximumSum(nums));

            //Case 2
            nums = [10, 12, 19, 14];
            Console.WriteLine(MaximumSum(nums));
        }
        public int MaximumSum(int[] nums)
        {
            /* Constraints
             * 1. 1 <= nums.Length <= 10^5
             * 2. 1 <= nums[i] <= 10^9
            */
            int n = nums.Length;
            //元素nums[i]最大值為10^9, 減一為9個9，位數和為9*9 = 81所以位數和最大是81，方便所引容量設為82
            //因為元素nums[i]最小為1，所以沒有位數和為0的數字，digitsumNumMap[0]用不到
            int[] digitsumNumMap = new int[82];
            int maxNumSum = -1;

            int digitSum;
            int num;
            int copy;
            for (int i = 0; i < n; i++)
            {
                digitSum = 0;
                num = copy = nums[i];
                while(copy > 0)
                {
                    digitSum += copy % 10;
                    copy /= 10;
                }

                if (digitsumNumMap[digitSum] == 0)
                {
                    digitsumNumMap[digitSum] = num;
                    continue;
                }
                maxNumSum = Math.Max(maxNumSum, digitsumNumMap[digitSum] + num);
                digitsumNumMap[digitSum] = Math.Max(digitsumNumMap[digitSum], num);
            }

            return maxNumSum;
        }
        //public int MaximumSum(int[] nums)
        //{
        //    int[] digitNumMap = new int[82];
        //    int n = nums.Length;
        //    int maxNumSum = -1;

        //    int digitSum;
        //    ReadOnlySpan<char> span;
        //    int vectorSize = Vector<byte>.Count;//32:一次並行處理32字符
        //    byte[] bytes = new byte[vectorSize];//大小一定是也只能是32
        //    //隨每個元素位數長短而變，控制後面元素轉型成bytes陣列與位數和的長度，這樣也不用擔心干擾到
        //    //下一次迭代的數字
        //    int byteLength;
        //    Vector<byte> vector;//System.Numerics
        //    Vector<byte> zeroCharVector = new Vector<byte>((byte)'0');//不要用Vector<byte>.Zero，因為是計算ASCII差值
        //    for (int i = 0; i < n; i++)
        //    {
        //        span = nums[i].ToString().AsSpan();
        //        byteLength = span.Length;
        //        for (int j = 0; j < byteLength; j++)
        //        {
        //            bytes[j] = (byte)span[j];
        //        }
        //        vector = new Vector<byte>(bytes, 0);//從Vector的第0位開始填入bytes的元素
        //        vector -= zeroCharVector;//一次並行運算32位也只能是32位的字符
        //        digitSum = 0;
        //        for (int j = 0; j < byteLength; j++)
        //        {
        //            digitSum += vector[j];
        //        }

        //        if (digitNumMap[digitSum] == 0)
        //        {
        //            digitNumMap[digitSum] = nums[i];
        //            continue;
        //        }
        //        maxNumSum = Math.Max(maxNumSum, digitNumMap[digitSum] + nums[i]);
        //        digitNumMap[digitSum] = Math.Max(digitNumMap[digitSum], nums[i]);
        //    }

        //    return maxNumSum;
        //}

        //public int MaximumSum(int[] nums)
        //{
        //    Dictionary<int, int> digitNumDic = new Dictionary<int, int>();
        //    int maxNumsSum = -1;
        //    int digitSum;
        //    int copy;
        //    for (int i = 0; i < nums.Length; i++)
        //    {
        //        digitSum = 0;
        //        copy = nums[i];
        //        while (copy > 0)
        //        {
        //            digitSum += copy % 10;
        //            copy /= 10;
        //        }

        //        if (digitNumDic.TryGetValue(digitSum, out int num))
        //        {
        //            maxNumsSum = Math.Max(maxNumsSum, nums[i] + num);
        //            digitNumDic[digitSum] = Math.Max(nums[i], num);
        //        }
        //        else
        //        {
        //            digitNumDic[digitSum] = nums[i];
        //        }
        //    }

        //    return maxNumsSum;
        //}
    }
}