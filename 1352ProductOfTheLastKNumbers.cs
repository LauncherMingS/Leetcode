using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Leetcode.Program;

namespace Leetcode
{
    internal class _1352ProductOfTheLastKNumbers
    {
        public void Test()
        {
            ProductOfNumbers obj = new ProductOfNumbers();
            obj.Add(3);
            obj.Add(0);
            obj.Add(2);
            obj.Add(5);
            obj.Add(4);
            obj.GetProduct(2);
            obj.GetProduct(3);
            obj.GetProduct(4);
            obj.Add(8);
            obj.GetProduct(2);
        }
        public class ProductOfNumbers
        {
            List<int> list;
            public ProductOfNumbers()
            {
                list = new List<int>();
            }

            public void Add(int num)
            {
                if (num == 0)
                {
                    list.Clear();
                    return;
                }

                int count = list.Count;
                if (count == 0)
                {
                    list.Add(num);
                }
                else
                {
                    list.Add(num * list[count - 1]);
                }
            }

            public int GetProduct(int k)
            {
                int count = list.Count;
                if (count < k)
                {
                    return 0;
                }
                if (count == k)
                {
                    return list[count - 1];
                }
                return list[count - 1] / list[count - 1 - k];
            }
        }

        //public class ProductOfNumbers
        //{
        //    int[] nums;
        //    int currentIndex;
        //    int startIndex;
        //    public ProductOfNumbers()
        //    {
        //        nums = new int[40000];
        //        currentIndex = 0;
        //        startIndex = -1;
        //    }

        //    public void Add(int num)
        //    {
        //        if (num == 0)
        //        {
        //            startIndex = currentIndex++;
        //            return;
        //        }
        //        for (int i = startIndex + 1; i < currentIndex; i++)
        //        {
        //            nums[i] *= num;
        //        }
        //        nums[currentIndex++] = num;
        //    }

        //    public int GetProduct(int k)
        //    {
        //        Console.WriteLine(((currentIndex - k) > startIndex) ? nums[currentIndex - k] : 0);
        //        return ((currentIndex - k) > startIndex) ? nums[currentIndex - k] : 0;
        //    }
        //}
    }
}