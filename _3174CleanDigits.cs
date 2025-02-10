using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    internal class _3174CleanDigits
    {
        public void Test()
        {
            //Case 1
            string s = "abc";
            Console.WriteLine(ClearDigits(s));

            //Case 2
            s = "cb34";
            Console.WriteLine(ClearDigits(s));
        }
        public string ClearDigits(string s)
        {
            StringBuilder sb = new StringBuilder(s);
            int countDigit = 0;
            for (int i = sb.Length - 1; i >= 0; i--)
            {
                if (char.IsDigit(sb[i]))
                {
                    sb.Remove(i, 1);
                    countDigit++;
                }
                else if (countDigit > 0)
                {
                    sb.Remove(i, 1);
                    countDigit--;
                }
            }

            return sb.ToString();
        }
        //public string ClearDigits(string s)
        //{
        //    Stack<char> stack = new Stack<char>();

        //    for (int i = 0; i < s.Length; i++)
        //    {
        //        if (char.IsLetter(s[i]))
        //        {
        //            stack.Push(s[i]);
        //        }
        //        else if (stack.Count > 0)
        //        {
        //            stack.Pop();
        //        }
        //    }

        //    StringBuilder sb = new StringBuilder();
        //    while (stack.Count > 0)
        //    {
        //        sb.Insert(0, stack.Pop());
        //    }

        //    return sb.ToString();
        //}
    }
}