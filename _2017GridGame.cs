using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    internal class _2017GridGame
    {
        public void Test()
        {
            //Case 1
            int[][] grid = [[2, 5, 4], [1, 5, 1]];
            Console.WriteLine(GridGame(grid));

            //Case 2
            grid = [[3, 3, 1], [8, 5, 2]];
            Console.WriteLine(GridGame(grid));

            //Case 3
            grid = [[1, 3, 1, 15], [1, 3, 3, 1]];
            Console.WriteLine(GridGame(grid));

            //Case 4
            grid = [[20, 3, 20, 17, 2, 12, 15, 17, 4, 15], [20, 10, 13, 14, 15, 5, 2, 3, 14, 3]];
            Console.WriteLine(GridGame(grid));
        }
        /*
        這題有一個迷思是:第一個機器人的目的是要讓第二個機器人收集的分數最小化，而第一個機器人
        找出一條分數最多的路徑，並不能使第二個機器人收集的分數最小化，要注意！！！
        */
        //Leetcode提供的解法
        public long GridGame(int[][] grid)
        {
            int n = grid[0].Length;

            long firstRowSum = 0;
            for (int j = 0; j < n; j++) firstRowSum += grid[0][j];

            long secondRowSum = 0;
            long minimumSum = long.MaxValue;
            for (int j = 0; j < n; j++)
            {
                firstRowSum -= grid[0][j];

                minimumSum = Math.Min(minimumSum, Math.Max(secondRowSum, firstRowSum));
                secondRowSum += grid[1][j];
            }

            return minimumSum;
        }

        //chatGPT提供的解法
        //public long GridGame(int[][] grid)
        //{
        //    int n = grid[0].Length;

        //    long[] topPrefixSum = new long[n + 1];
        //    long[] bottomPrefixSum = new long[n + 1];
        //    for (int j = 0;j < n;j++)
        //    {
        //        topPrefixSum[j + 1] = topPrefixSum[j] + grid[0][j];
        //        bottomPrefixSum[j + 1] = bottomPrefixSum[j] +  grid[1][j];
        //    }

        //    long result = long.MaxValue;
        //    for (int j = 0;j < n; j++)
        //    {
        //        long topRemaining = topPrefixSum[n] - topPrefixSum[j + 1];
        //        long bottomRemaining = bottomPrefixSum[j];

        //        long secondRobotScore = Math.Max(topRemaining, bottomRemaining);

        //        result = Math.Min(result, secondRobotScore);
        //    }

        //    return result;
        //}
    }
}