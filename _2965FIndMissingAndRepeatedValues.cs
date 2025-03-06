using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static Leetcode.Program;

namespace Leetcode
{
    internal class _2965FIndMissingAndRepeatedValues
    {
        public void Test()
        {
            //Case 1
            int[][] grid = [[1, 3], [2, 2]];
            PrintArray(FindMissingAndRepeatedValues(grid));

            //Case 2
            grid = [[9, 1, 7], [8, 9, 2], [3, 4, 6]];
            PrintArray(FindMissingAndRepeatedValues(grid));
        }


        public int[] FindMissingAndRepeatedValues(int[][] grid)
        {
            int length = grid.Length;
            int[] numCount = new int[length * length + 1];
            int[] repeatedMissingNum = new int[2];
            int i;
            for (i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (numCount[grid[i][j]] == 0)
                    {
                        ++numCount[grid[i][j]];
                    }
                    else
                    {
                        repeatedMissingNum[0] = grid[i][j];
                    }
                }
            }

            int lengthSquare = length * length;
            for (i = 1; i <= lengthSquare; i++)
            {
                if (numCount[i] == 0)
                {
                    repeatedMissingNum[1] = i;
                    break;
                }
            }

            return repeatedMissingNum;
        }
    }
}