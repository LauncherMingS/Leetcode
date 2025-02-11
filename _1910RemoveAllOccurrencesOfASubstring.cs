using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    internal class _1910RemoveAllOccurrencesOfASubstring
    {
        public void Test()
        {
            //Case 1
            string s = "daabcbaabcbc";
            string part = "abc";
            //Console.WriteLine(RemoveOccurrences(s, part));

            ////Case 2
            //s = "axxxxyyyyb";
            //part = "xy";
            //Console.WriteLine(RemoveOccurrences(s, part));

            ////Case 3
            //s = "ccctltctlltlb";
            //part = "ctl";
            //Console.WriteLine(RemoveOccurrences(s, part));

            //Case 4
            s = "gjzgbpggjzgbpgsvpwdk";
            part = "gjzgbpg";
            Console.WriteLine(RemoveOccurrences(s, part));

            //Case 5
            s = "wwwwwwwwwwwwwwwwwwwwwvwwwwswxwwwwsdwxweeohapwwzwuwajrnogb";
            part = "w";
            Console.WriteLine(RemoveOccurrences(s, part));
        }
        public string RemoveOccurrences(string s, string part)
        {
            Stack<char> stack = new Stack<char>();
            char[] temp = new char[part.Length];
            for (int i = 0;i < s.Length;i++)
            {
                stack.Push(s[i]);
                if (s[i] == part[part.Length - 1] && stack.Count >= part.Length)
                {
                    for (int j = part.Length - 1;j >= 0;j--)
                    {
                        temp[j] = stack.Pop();
                        if (temp[j] != part[j])
                        {
                            for (int k = j;k < part.Length;k++)
                            {
                                stack.Push(temp[k]);
                            }
                            break;
                        }
                    }
                }
            }

            StringBuilder sb = new StringBuilder();
            while (stack.Count > 0)
            {
                sb.Insert(0, stack.Pop());
            }

            return sb.ToString();
        }
        //public string RemoveOccurrences(string s, string part)
        //{
        //    int index;
        //    while((index = s.IndexOf(part, StringComparison.Ordinal)) > -1)
        //    {
        //        s = s[..index] + s[(index + part.Length)..];
        //    }

        //    return s;
        //}
        /*
        slice
        [start..end]
        start ~ end - 1

        string str = "abcdef";
        s[..3] = "abc"
        s[2..] = "cdef"
        s[1..4] = "bcd"
        s[^1] = "f", s.length - 1
        s[^2] = "e", s.length - 2
        s[^3..] = "def"
        *** s[..^2] = "abcd", because [^2] is end, s.length - 2 - 1
        
        */
    }
}