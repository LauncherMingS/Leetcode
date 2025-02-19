using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    internal class _1415TheKthLexicographicalStringOfAllHappyStringsOfLengthN
    {
        public void Test()
        {
            //Case 1
            int n = 1;
            int k = 3;
            Console.WriteLine(GetHappyString(n, k));

            //Case 2
            n = 1;
            k = 4;
            Console.WriteLine(GetHappyString(n, k));

            //Case 3
            n = 3;
            k = 9;
            Console.WriteLine(GetHappyString(n, k));
        }
        public string GetHappyString(int n, int k)
        {
            int length = 1 << (n - 1);
            if (k > 3 * length)
            {
                return string.Empty;
            }

            //StringBuilder happyString = new StringBuilder();
            char[] happyString = new char[n];
            int i = 0;
            //char[] happySet = ['a', 'b', 'c'];
            int previousLetter = 3;//happySet.Length;
            int quotient;
            while (length > 0)
            {
                quotient = (k - 1) / length;
                k = (k - 1) % length + 1;
                length >>= 1;
                #region origin
                //quotient = k / length;
                //remainder = k % length;
                //if (remainder != 0)
                //{
                //    k = remainder;
                //}
                //else
                //{
                //    k = length;
                //    quotient--;
                //}
                //length /= 2;
                #endregion

                if (quotient >= previousLetter)
                {
                    quotient++;
                }
                happyString[i++] = (char)('a' + quotient);
                //happyString.Append(happySet[quotient]);
                previousLetter = quotient;
            }

            return new string(happyString);
        }
    }
}