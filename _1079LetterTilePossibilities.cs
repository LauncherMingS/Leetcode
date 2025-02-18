using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    internal class _1079LetterTilePossibilities
    {
        public void Test()
        {
            //Case 1
            string tiles = "AAB";
            Console.WriteLine(NumTilePossibilities(tiles));

            //Case 2
            tiles = "AAABBC";
            Console.WriteLine(NumTilePossibilities(tiles));

            //Case 3
            tiles = "V";
            Console.WriteLine(NumTilePossibilities(tiles));
        }

        Dictionary<char, int> countDic;
        public int NumTilePossibilities(string tiles)
        {
            countDic = new Dictionary<char, int>();
            char c;
            for (int i = 0; i < tiles.Length; i++)
            {
                c = tiles[i];
                if (!countDic.ContainsKey(c))
                {
                    countDic[c] = 0;
                }
                countDic[c]++;
            }

            return Backtrack();
        }
        public int Backtrack()
        {
            int sum = 0;
            foreach (char c in countDic.Keys)
            {
                if (countDic[c] == 0)
                {
                    continue;
                }

                sum++;
                countDic[c]--;
                sum += Backtrack();
                countDic[c]++;
            }

            return sum;
        }
    }
}