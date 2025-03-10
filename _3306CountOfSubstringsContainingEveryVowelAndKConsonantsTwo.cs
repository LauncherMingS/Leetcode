using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    internal class _3306CountOfSubstringsContainingEveryVowelAndKConsonantsTwo
    {
        public void Test()
        {
            //Case 1
            string word = "aeioqq";
            int k = 1;
            //Console.WriteLine(CountOfSubstrings(word, k));

            //Case 2
            word = "aeiou";
            k = 0;
            //Console.WriteLine(CountOfSubstrings(word, k));

            //Case 3
            word = "ieaouqqieaouqq";
            k = 1;
            Console.WriteLine(CountOfSubstrings(word, k));
        }

        //Leetcode
        string word;

        public long CountOfSubstrings(string word, int k)
        {
            this.word = word;
            return AtLeastK(k) - AtLeastK(k + 1);
        }

        public long AtLeastK(int k)
        {
            long count = 0;
            int consonantCount = 0;
            int leftPointer = 0;
            HashSet<char> vowelSet = new HashSet<char>(new char[] { 'a', 'e', 'i', 'o', 'u' });
            Dictionary<char, int> vowelDic = new Dictionary<char, int>();
            int length = word.Length;
            char t_currentLetter;
            char t_lastLetter;
            for (int rightPointer = 0 ;rightPointer < length;rightPointer++)
            {
                t_currentLetter = word[rightPointer];
                if (vowelSet.Contains(t_currentLetter))
                {
                    if (!vowelDic.ContainsKey(t_currentLetter))
                    {
                        vowelDic[t_currentLetter] = 0;
                    }
                    vowelDic[t_currentLetter]++;
                }
                else
                {
                    consonantCount++;
                }

                while (vowelDic.Count == 5 && consonantCount >= k)
                {
                    count += length - rightPointer;
                    t_lastLetter = word[leftPointer];
                    if (vowelSet.Contains(t_lastLetter))
                    {
                        vowelDic[t_lastLetter]--;
                        if (vowelDic[t_lastLetter] == 0)
                        {
                            vowelDic.Remove(t_lastLetter);
                        }
                    }
                    else
                    {
                        consonantCount--;
                    }
                    leftPointer++;
                }
            }

            return count;
        }

        //Fail
        //public long CountOfSubstrings(string word, int k)
        //{
        //    //Filter vowel use
        //    HashSet<char> vowelSet = new HashSet<char>(new char[] { 'a', 'e', 'i', 'o', 'u' });
        //    int vowelCountLength = 6;
        //    int[] vowelCountArray = new int[vowelCountLength];
        //    //If any vowel has not exactly one, isComplete is false, or ture
        //    bool isComplete = false;
        //    //5 + k: 'a', 'e', 'i', 'o', 'u' and k consonants(子音)
        //    //[-1]: rightPointer - leftPointer [+ 1] >= substringLength
        //    int substringLength = 5 + k - 1;
        //    int substringCount = 0;
        //    int leftPointer = 0;
        //    int length = word.Length;
        //    for (int rightPointer = 0; rightPointer < length; rightPointer++)
        //    {
        //        if (vowelSet.Contains(word[rightPointer]))
        //        {
        //            vowelCountArray[(word[rightPointer] - 'a') / 4]++;
        //            isComplete = true;
        //            for (int j = 0; j < vowelCountLength; j++)
        //            {
        //                if (j == 4)
        //                {
        //                    continue;
        //                }

        //                if (vowelCountArray[j] != 1)
        //                {
        //                    isComplete = false;
        //                    break;
        //                }
        //            }
        //        }

        //        if (rightPointer >= substringLength)
        //        {
        //            if (isComplete)
        //            {
        //                substringCount++;
        //            }

        //            if (vowelSet.Contains(word[leftPointer]))
        //            {
        //                vowelCountArray[(word[leftPointer] - 'a') / 4]--;
        //                isComplete = true;
        //                for (int j = 0; j < vowelCountLength; j++)
        //                {
        //                    if (j == 4)
        //                    {
        //                        continue;
        //                    }

        //                    if (vowelCountArray[j] != 1)
        //                    {
        //                        isComplete = false;
        //                        break;
        //                    }
        //                }
        //            }

        //            leftPointer++;
        //        }
        //    }

        //    return substringCount;
        //}
    }
}