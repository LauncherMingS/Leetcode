using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    internal class _1765MapOfHightestPeak
    {
        public void Test()
        {
            //Case 1
            int[][] isWater = [[0, 1], [0, 0]];
            Program.PrintArray(HighestPeak(isWater));

            //Case 2
            //isWater = [[0, 0, 1], [1, 0, 0], [0, 0, 0]];
            //Program.PrintArray(HighestPeak(isWater));
        }
        public int[][] HighestPeak(int[][] isWater)
        {
            int m = isWater.Length;
            int n = isWater[0].Length;
            int[][] newMap = new int[m][];

            //先將標記為水的地方加入queue，作為BFS的啟動條件，順便建陣列
            Queue<(int, int)> queue = new Queue<(int, int)>();
            for (int i = 0; i < m; i++)
            {
                newMap[i] = new int[n];
                for (int j = 0; j < n; j++)
                    if (isWater[i][j] == 1) queue.Enqueue((i, j));
            }

            //開始BFS，向東西北南方向，先檢查邊界，再透過isWater[i][j]為0的方式辨別
            //此處的高度是否更新過，先將下一處的座標在isWater上標記為1表示已經更新過，再更新高度，
            //並將座標加入queue，繼續擴散檢查
            while (queue.Count > 0)
            {
                (int r, int c) p = queue.Dequeue();
                if (p.c - 1 >= 0 && isWater[p.r][p.c - 1] == 0)//東
                {
                    isWater[p.r][p.c - 1] = 1;
                    newMap[p.r][p.c - 1] = newMap[p.r][p.c] + 1;
                    queue.Enqueue((p.r, p.c - 1));
                }
                if (p.c + 1 < n && isWater[p.r][p.c + 1] == 0)//西
                {
                    isWater[p.r][p.c + 1] = 1;
                    newMap[p.r][p.c + 1] = newMap[p.r][p.c] + 1;
                    queue.Enqueue((p.r, p.c + 1));
                }
                if (p.r - 1 >= 0 && isWater[p.r - 1][p.c] == 0)//北
                {
                    isWater[p.r - 1][p.c] = 1;
                    newMap[p.r - 1][p.c] = newMap[p.r][p.c] + 1;
                    queue.Enqueue((p.r - 1, p.c));
                }
                if (p.r + 1 < m && isWater[p.r + 1][p.c] == 0)//南
                {
                    isWater[p.r + 1][p.c] = 1;
                    newMap[p.r + 1][p.c] = newMap[p.r][p.c] + 1;
                    queue.Enqueue((p.r + 1, p.c));
                }
            }

            return newMap;
        }
    }
}