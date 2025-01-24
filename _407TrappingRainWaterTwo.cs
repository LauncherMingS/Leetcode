using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    internal class _407TrappingRainWaterTwo
    {
        public void Test()
        {
            //Case 1
            int[][] heightMap = [[1, 4, 3, 1, 3, 2], [3, 2, 1, 3, 2, 4], [2, 3, 3, 2, 3, 1]];
            Console.WriteLine(TrapRainWater(heightMap));

            //Case 2
            heightMap = [[3, 3, 3, 3, 3], [3, 2, 2, 2, 3], [3, 2, 1, 2, 3], [3, 2, 2, 2, 3], [3, 3, 3, 3, 3]];
            Console.WriteLine(TrapRainWater(heightMap));
        }
        public int TrapRainWater(int[][] heightMap)
        {
            int m = heightMap.Length;
            int n = heightMap[0].Length;
            if (m < 3 || n < 3) return 0;

            bool[][] visited = new bool[m][];
            PriorityQueue<(int x, int y), int> queue = new PriorityQueue<(int r, int c), int>();
            n -= 1;
            for (int i = 0; i < m; i++)
            {
                visited[i] = new bool[n + 1];
                queue.Enqueue((i, 0), heightMap[i][0]);
                queue.Enqueue((i, n), heightMap[i][n]);
                visited[i][0] = visited[i][n] = true;
            }
            m -= 1;
            for (int j = 1; j < n; j++)
            {
                queue.Enqueue((0, j), heightMap[0][j]);
                queue.Enqueue((m, j), heightMap[m][j]);
                visited[0][j] = visited[m][j] = true;
            }

            int countWater = 0;
            while (queue.Count > 0)
            {
                (int y, int x) p = queue.Dequeue();

                int currentHeight = heightMap[p.y][p.x];
                if (p.x - 1 >= 0 && !visited[p.y][p.x - 1])//left
                {
                    visited[p.y][p.x - 1] = true;
                    countWater += Math.Max(0, currentHeight - heightMap[p.y][p.x - 1]);

                    heightMap[p.y][p.x - 1] = Math.Max(currentHeight, heightMap[p.y][p.x - 1]);
                    queue.Enqueue((p.y, p.x - 1), heightMap[p.y][p.x - 1]);
                }
                if (p.x + 1 <= n && !visited[p.y][p.x + 1])//right
                {
                    visited[p.y][p.x + 1] = true;
                    countWater += Math.Max(0, currentHeight - heightMap[p.y][p.x + 1]);

                    heightMap[p.y][p.x + 1] = Math.Max(currentHeight, heightMap[p.y][p.x + 1]);
                    queue.Enqueue((p.y, p.x + 1), heightMap[p.y][p.x + 1]);
                }
                if (p.y - 1 >= 0 && !visited[p.y - 1][p.x])//forward
                {
                    visited[p.y - 1][p.x] = true;
                    countWater += Math.Max(0, currentHeight - heightMap[p.y - 1][p.x]);

                    heightMap[p.y - 1][p.x] = Math.Max(currentHeight, heightMap[p.y - 1][p.x]);
                    queue.Enqueue((p.y - 1, p.x), heightMap[p.y - 1][p.x]);
                }
                if (p.y + 1 <= m && !visited[p.y + 1][p.x])//backward
                {
                    visited[p.y + 1][p.x] = true;
                    countWater += Math.Max(0, currentHeight - heightMap[p.y + 1][p.x]);

                    heightMap[p.y + 1][p.x] = Math.Max(currentHeight, heightMap[p.y + 1][p.x]);
                    queue.Enqueue((p.y + 1, p.x), heightMap[p.y + 1][p.x]);
                }
            }

            return countWater;
        }
        //public int TrapRainWater(int[][] heightMap)
        //{
        //    int m = heightMap.Length;
        //    int n = heightMap[0].Length;

        //    if (m < 3 || n < 3) return 0; // 太小的矩陣無法存水

        //    var visited = new bool[m, n];
        //    var pq = new PriorityQueue<Cell, int>();

        //    // 將邊界加入優先隊列
        //    for (int i = 0; i < m; i++)
        //    {
        //        for (int j = 0; j < n; j++)
        //        {
        //            if (i == 0 || i == m - 1 || j == 0 || j == n - 1)
        //            {
        //                pq.Enqueue(new Cell(i, j, heightMap[i][j]), heightMap[i][j]);
        //                visited[i, j] = true;
        //            }
        //        }
        //    }

        //    int totalWater = 0;
        //    int[][] directions = new int[][] {
        //new int[] { 0, 1 }, new int[] { 0, -1 },
        //new int[] { 1, 0 }, new int[] { -1, 0 }
        //};
        //    // 開始 BFS
        //    while (pq.Count > 0)
        //    {
        //        var cell = pq.Dequeue();

        //        Console.WriteLine(cell.X + ", " + cell.Y + ", " + cell.Height);
        //        foreach (var dir in directions)
        //        {
        //            int ni = cell.X + dir[0];
        //            int nj = cell.Y + dir[1];

        //            if (ni >= 0 && ni < m && nj >= 0 && nj < n && !visited[ni, nj])
        //            {
        //                visited[ni, nj] = true;
        //                int water = Math.Max(0, cell.Height - heightMap[ni][nj]);
        //                totalWater += water;

        //                // 更新高度為當前堤防高度
        //                pq.Enqueue(new Cell(ni, nj, Math.Max(cell.Height, heightMap[ni][nj])), Math.Max(cell.Height, heightMap[ni][nj]));
        //            }
        //        }
        //    }

        //    return totalWater;
        //}
        private class Cell : IComparable<Cell>
        {
            public int X { get; }
            public int Y { get; }
            public int Height { get; }

            public Cell(int x, int y, int height)
            {
                X = x;
                Y = y;
                Height = height;
            }

            public int CompareTo(Cell other)
            {
                return Height.CompareTo(other.Height);
            }
        }
    }
}