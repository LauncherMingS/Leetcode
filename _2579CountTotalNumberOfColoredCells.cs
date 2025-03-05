using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    internal class _2579CountTotalNumberOfColoredCells
    {
        public void Test()
        {
            //Case 1
            int n = 1;
            Console.WriteLine(ColoredCells(n));

            //Case 2
            n = 69675;
            Console.WriteLine(ColoredCells(n));
        }
        public long ColoredCells(int n)
        {
            //1 + 4 * (1 + (n - 1)) * (n - 1) / 2
            return 1 + 2L * n * (n - 1);

            //find the pattern
            /*
            1, 1
            2, 1 + 4 = 1 + 4 * 1
            3, 5 + (4 + 4) = 5 + 4 * 2
            4, 13 + (4 + 8) = 13 + 4 * 3
            5, 25 + (4 + 12) = 25 + 4 * 4
            6, 41 + (4 + 16) = 41 + 4 * 5
            n, a[n - 1] + 4 * (n - 1)

            1, 1
            2, 1 + 4 * 1
            3, 1 + 4 * 1 + 4 * 2 = 1 + 4 * 3
            4, 1 + 4 * 1 + 4 * 2 + 4 * 3 = 1 + 4 * 6
            5, 1 + 4 * 1 + 4 * 2 + 4 * 3 + 4 * 4 = 1 + 4 * 10
            6, 1 + 4 * 1 + 4 * 2 + 4 * 3 + 4 * 4 + 4 * 5 = 1 + 4 * 15
            n, 1 + 4 * (1 + (n - 1)) * (n - 1) / 2
            */
        }
    }
}