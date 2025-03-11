using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    internal class _1358NumberOfSubstringsContainingAllThreeCharacters
    {
        public void Test()
        {
            //Case 1
            string s = "abcabc";
            //Console.WriteLine(NumberOfSubstrings(s));

            //Case 2
            s = "aaacb";
            Console.WriteLine(NumberOfSubstrings(s));

            //Case 3
            s = "abc";
            //Console.WriteLine(NumberOfSubstrings(s));
        }

        public int NumberOfSubstrings(string s)
        {
            int length = s.Length;
            int leftPointer = 0;
            int count = 0;
            int[] letterCount = new int[3];//'a', 'b', 'c'

            for (int rightPointer = 0;rightPointer < length;rightPointer++)
            {
                letterCount[s[rightPointer] - 'a']++;

                while (letterCount[0] > 0 && letterCount[1] > 0 && letterCount[2] > 0)
                {
                    count += length - rightPointer;
                    letterCount[s[leftPointer] - 'a']--;
                    leftPointer++;
                }
            }

            return count;
        }
    }
}