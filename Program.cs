namespace Leetcode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var _2017 = new _2017GridGame();
            _2017.Test();

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
