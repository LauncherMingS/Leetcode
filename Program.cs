using System.Diagnostics;
using System.Numerics;
using System.Runtime.Intrinsics.X86;
using System.Text;

namespace Leetcode
{
    internal class Program
    {
        private static Stopwatch stopwatch;
        static void Main(string[] args)
        {
            #region
            //var _2017 = new _2017GridGame();
            //_2017.Test();

            //var _1765 = new _1765MapOfHightestPeak();
            //_1765.Test();

            //var _1267 = new _1267CountServersThatCommunicate();
            //_1267.Test();

            //var _802 = new _802FindEventualSafeStates();
            //_802.Test();

            //var _407 = new _407TrappingRainWaterTwo();
            //_407.Test();

            //var _3105 = new _3105LongestStrictlyIncreasingOrStrictlyDecreasingSubarray();
            //_3105.Test();

            //var _1800 = new _1800MaximumAscendingSubarraySum();
            //_1800.Test();

            //var _1790 = new _1790CheckIfOneStringSwapCanMakeStringsEqual();
            //_1790.Test();

            //var _1726 = new _1726TupleWithSameProduct();
            //_1726.Test();

            //var _3160 = new _3160FindTheNumberOfDistinctColorsAmongTheBalls();
            //_3160.Test();

            //var _2349 = new _2349DesignANumberContainerSystem();
            //_2349.Test();

            //var _3174 = new _3174CleanDigits();
            //_3174.Test();

            //var _1910 = new _1910RemoveAllOccurrencesOfASubstring();
            //_1910.Test();

            //var _2342 = new _2342MaxSumOfAPairWithEqualSumOfDigits();
            //_2342.Test();

            //var _3066 = new _3066MinimumOperationsToExceedThresholdValueTwo();
            //_3066.Test();

            //var _1352 = new _1352ProductOfTheLastKNumbers();
            //_1352.Test();

            //var _1079 = new _1079LetterTilePossibilities();
            //_1079.Test();

            //var _2375 = new _2375ConstructSmallestNumberFromDIString();
            //_2375.Test();

            //var _1415 = new _1415TheKthLexicographicalStringOfAllHappyStringsOfLengthN();
            //_1415.Test();

            //var _1980 = new _1980FindUniqueBinaryString();

            //var _1261 = new _1261FindElementsInAContaminatedBinaryTree();

            //var _2467 = new _2467MostProfitablePathInATree();
            //_2467.Test();

            //var _1524 = new _1524NumberOfSub_arraysWithOddSum();
            //_1524.Test();
            #endregion

            var _1749 = new _1749MaximumAbsoluteSumOfAnySubarray();
            _1749.Test();

            Console.Read();
        }
        public static string PrintArray<T>(T[] array, bool is2DUse = false)
        {
            if (array == null)
            {
                if (!is2DUse) Console.WriteLine("Array is null !!!");
                return "null";
            }
            if (array.Length == 0)
            {
                if (!is2DUse) Console.WriteLine("Array is empty !!!");
                return "[]";
            }

            string formattedString = "[" + string.Join(", ", array.Select(element => element.ToString())) + "]";
            if (!is2DUse) Console.WriteLine(formattedString);
            return formattedString;
        }
        public static string PrintArray<T>(T[][] array)
        {
            if (array == null)
            {
                Console.WriteLine("2DArray is null !!!");
                return "null";
            }
            if (array.Length == 0)
            {
                Console.WriteLine("2DArray is empty !!!");
                return "[[]]";
            }

            string formattedString = "[" + string.Join(", ", array.Select(elment => PrintArray(elment, true))) + "]";
            Console.WriteLine(formattedString);
            return formattedString;
        }
        public static void FillArray<T>(T[] array, T element)
        {
            for (int i = 0; i < array.Length; ++i)
                array[i] = element;
        }
        public static string PrintCollection<T>(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                Console.WriteLine("Collection is null!!!");
                return "null";
            }

            string formattingString = "[" + string.Join(", ", collection) + "]";
            Console.WriteLine(formattingString);
            return formattingString;
        }
        public static void TimingStart()
        {
            if (stopwatch == null)
            {
                stopwatch = new Stopwatch();
                stopwatch.Start();
            }
            else
            {
                stopwatch.Restart();
            }
        }
        public static double TimingEnd()
        {
            stopwatch.Stop();
            return stopwatch.Elapsed.TotalMilliseconds;
        }
    }
}