namespace Leetcode
{
    internal class Program
    {
        static void Main(string[] args)
        {
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

            var _1726 = new _1726TupleWithSameProduct();
            _1726.Test();

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
    }
}
