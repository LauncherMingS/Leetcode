using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    internal class _1790CheckIfOneStringSwapCanMakeStringsEqual
    {
        public void Test()
        {
            //Case 1
            string s1 = "bank";
            string s2 = "kanb";
            //Console.WriteLine(AreAlmostEqual(s1, s2));

            ////Case 2
            //s1 = "attack";
            //s2 = "defend";
            //Console.WriteLine(AreAlmostEqual(s1, s2));

            ////Case 3
            //s1 = "kelb";
            //s2 = "kelb";
            //Console.WriteLine(AreAlmostEqual(s1, s2));

            ////Case 4
            //s1 = "abcd";
            //s2 = "dcba";
            //Console.WriteLine(AreAlmostEqual(s1, s2));

            //Case 5
            s1 = "aa";
            s2 = "ac";
            Console.WriteLine(AreAlmostEqual(s1, s2));
        }
        //public bool AreAlmostEqual(string s1, string s2)
        //{
        //    int n = s1.Length;
        //    Dictionary<char, int> letterFrequence = new Dictionary<char, int>();
        //    int notEqualCount = 0;
        //    for (int i = 0;i < n;i++)
        //    {
        //        if (!letterFrequence.ContainsKey(s1[i]))
        //        {
        //            letterFrequence.Add(s1[i], 0);
        //        }
        //        letterFrequence[s1[i]]++;

        //        if (s1[i] != s2[i] && ++notEqualCount > 2)
        //        {
        //            return false;
        //        }
        //    }

        //    for (int i = 0;i < n;i++)
        //    {
        //        if (!letterFrequence.ContainsKey(s2[i]) || --letterFrequence[s2[i]] < 0)
        //        {
        //            return false;
        //        }
        //    }

        //    return true;
        //}
        public bool AreAlmostEqual(string s1, string s2)
        {
            int n = s1.Length;
            int notMatchCount = 0;
            char previousChar1 = '\0';
            char previousChar2 = '\0';
            for (int i = 0;i < n;i++)
            {
                if (s1[i] != s2[i])
                {
                    if (++notMatchCount > 2)
                    {
                        return false;
                    }

                    if (previousChar1 != '\0')
                    {
                        if (previousChar1 != s2[i] || previousChar2 != s1[i])
                        {
                            return false;
                        }
                    }
                    else
                    {
                        previousChar1 = s1[i];
                        previousChar2 = s2[i];
                    }
                }
            }

            return notMatchCount != 1;
        }
    }
}