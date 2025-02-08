using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    internal class _3160FindTheNumberOfDistinctColorsAmongTheBalls
    {
        public void Test()
        {
            //Case 1
            int limit = 4;
            int[][] queries = [[1, 4], [2, 5], [1, 3], [3, 4]];
            Program.PrintArray(QueryResults(limit, queries));

            //Case 2
            limit = 4;
            queries = [[0, 1], [1, 2], [2, 2], [3, 4], [4, 5]];
            Program.PrintArray(QueryResults(limit, queries));

            //Case 3
            limit = 1;
            queries = [[0, 1], [0, 4], [1, 2], [1, 5], [1, 4]];
            Program.PrintArray(QueryResults(limit, queries));

            //Case 4
            limit = 1;
            queries = [[0, 1], [1, 4], [1, 1], [1, 4], [1, 1]];
            Program.PrintArray(QueryResults(limit, queries));
        }
        public int[] QueryResults(int limit, int[][] queries)
        {
            Dictionary<int, int> ballColors = new Dictionary<int, int>();
            Dictionary<int, int> colorCount = new Dictionary<int, int>();
            int[] result = new int[queries.Length];

            for (int i = 0;i < queries.Length;i++)
            {
                int ball = queries[i][0];
                int color = queries[i][1];

                if (ballColors.ContainsKey(ball))
                {
                    int oldColor = ballColors[ball];

                    if (oldColor != color)
                    {
                        colorCount[oldColor]--;
                        if (colorCount[oldColor] == 0)
                        {
                            colorCount.Remove(oldColor);
                        }

                        if (!colorCount.ContainsKey(color))
                        {
                            colorCount[color] = 0;
                        }
                        colorCount[color]++;

                        ballColors[ball] = color;
                    }
                }
                else
                {
                    ballColors[ball] = color;
                    if (!colorCount.ContainsKey(color))
                    {
                        colorCount[color] = 0;
                    }
                    colorCount[color]++;
                }

                result[i] = colorCount.Count;
            }

            return result;
        }
    }
}