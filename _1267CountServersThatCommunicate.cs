using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    internal class _1267CountServersThatCommunicate
    {
        public void Test()
        {
            //Case 1
            int[][] grid = [[1, 0], [0, 1]];
            Console.WriteLine(CountServers(grid));

            //Case 2
            grid = [[1, 0], [1, 1]];
            Console.WriteLine(CountServers(grid));

            //Case 3
            grid = [[1, 1, 0, 0], [0, 0, 1, 0], [0, 0, 1, 0], [0, 0, 0, 1]];
            Console.WriteLine(CountServers(grid));
        }
        public int CountServers(int[][] grid)
        {
            int m = grid.Length;
            int n = grid[0].Length;

            int[] rowCount = new int[m];
            int[] columnCount = new int[n];
            for (int i = 0;i < m;i++)
                for (int j = 0; j < n; j++)
                    if (grid[i][j] == 1)
                    {
                        rowCount[i]++;
                        columnCount[j]++;
                    }

            int count = 0;
            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                    if (grid[i][j] == 1 && (rowCount[i] > 1 || columnCount[j] > 1))
                        count++;

            return count;
        }
    }
}
