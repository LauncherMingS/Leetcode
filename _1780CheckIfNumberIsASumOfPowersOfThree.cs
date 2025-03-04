using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    internal class _1780CheckIfNumberIsASumOfPowersOfThree
    {
        public void Test()
        {
            //Case 1
            int n = 12;
            Console.WriteLine(CheckPowersOfThree(n));

            //Case 2
            n = 91;
            Console.WriteLine(CheckPowersOfThree(n));

            //Case 3
            n = 21;
            Console.WriteLine(CheckPowersOfThree(n));
        }
        /*
        根據題目觀察，給定的n只能由不同"3的冪次"並且同一個3的冪次"只能有一個"，例如12由3的一次與二次
        "各一個"相加組成，1 * 3^1 + 1 * 3^2，換句話說，如果把12轉成3進制為110，每個位數只會出現0或1，
        要嘛有要嘛沒有，有個話也只能有一個。
        再來，21轉3進制為210，也就是2 * 3^2 + 1 * 3^1 + 0 * 3^0，有"兩個"3^2跟一個3^1，違反規則
         */
        public bool CheckPowersOfThree(int n)
        {
            const int THREE = 3;
            const int TWICE = 2;
            while(n > 0)
            {
                if (n % THREE == TWICE)//如果base是4以上，就需要換成n % THREE >= TWICE
                {
                    return false;
                }
                n /= THREE;
            }

            return true;
        }

        //public bool CheckPowersOfThree(int n)
        //{
        //    const int THREE = 3;
        //    int y = 1;

        //    while (y < n)
        //    {
        //        y *= THREE;
        //    }

        //    if (y == n)
        //    {
        //        return true;
        //    }

        //    y /= THREE;
        //    while (n > 0 && y != 0)
        //    {
        //        if (y <= n)
        //        {
        //            n -= y;
        //        }
        //        y /= THREE;
        //    }

        //    return (n == 0) ? true : false;
        //}
    }
}