using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Leetcode.Program;

namespace Leetcode
{
    internal class _2523ClosestPrimeNumbersInRange
    {
        public void Test()
        {
            PrintPrimeNumber(100);

            //Case 1
            int left = 10;
            int right = 19;
            PrintArray(ClosestPrimes(left, right));

            //Case 2
            left = 4;
            right = 6;
            PrintArray(ClosestPrimes(left, right));

            //Case 3
            left = 19;
            right = 31;
            PrintArray(ClosestPrimes(left, right));

            //Case 4
            left = 18;
            right = 72;
            PrintArray(ClosestPrimes(left, right));
        }

        public int[] ClosestPrimes(int left, int right)
        {
            bool[] isPrime = new bool[right + 1];
            Array.Fill(isPrime, true);
            isPrime[1] = isPrime[0] = false;
            for (int i = 2; i * i <= right; i++)
            {
                if (isPrime[i])
                {
                    for (int j = i * i; j <= right; j += i)
                    {
                        isPrime[j] = false;
                    }
                }
            }

            List<int> primeNums = new List<int>();
            int primeNumsIndex = 0;
            for (int i = left; i <= right; i++)
            {
                if (isPrime[i])
                {
                    primeNums.Add(i);
                    primeNumsIndex++;
                }
            }
            if (primeNumsIndex < 2)
            {
                return new int[2] { -1, -1 };
            }
            else if (primeNumsIndex == 2)
            {
                return new int[2] { primeNums[0], primeNums[1] };
            }

            primeNumsIndex--;
            int index = 0;
            int t_difference;
            int minDifference = primeNums[1] - primeNums[0];
            for (int i = 1; i < primeNumsIndex; i++)
            {
                t_difference = primeNums[i + 1] - primeNums[i];
                if (minDifference > t_difference)
                {
                    minDifference = t_difference;
                    index = i;
                }
            }

            return new int[2] { primeNums[index], primeNums[index + 1] };
        }

        //Sieve of Eratosthenes Algorithm:
        //Mark up composite number, and remain are prime numbers
        public void PrintPrimeNumber(int n)
        {
            //index directly map to num, the size is right + 1
            bool[] isPrime = new bool[n + 1];
            Array.Fill(isPrime, true);
            isPrime[1] = isPrime[0] = false;
            for (int i = 2; i * i <= n; i++)
            {
                if (isPrime[i])
                {
                    for (int j = i * i; j <= n; j += i)
                    {
                        isPrime[j] = false;
                    }
                }
            }

            Console.WriteLine("Prime Number: ");
            Console.Write(2);
            int total = 0;
            for (int i = 3; i <= n; i++)
            {
                if (isPrime[i])
                {
                    Console.Write(", " + i);
                    total++;
                }
            }
            Console.Write("\r\nTotal Prime Number: " + total);
        }
    }
}