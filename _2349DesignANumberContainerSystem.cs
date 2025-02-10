using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    internal class _2349DesignANumberContainerSystem
    {
        public void Test()
        {
            //Case 1
            NumberContainers obj = new NumberContainers();
            Console.WriteLine(obj.Find(10));
            obj.Change(2, 10);
            obj.Change(1, 10);
            obj.Change(3, 10);
            obj.Change(5, 10);
            Console.WriteLine(obj.Find(10));
            obj.Change(1, 20);
            Console.WriteLine(obj.Find(10));
        }
        public class NumberContainers
        {
            Dictionary<int, int> indexToNumber;
            Dictionary<int, SortedSet<int>> numberToIndices;
            public NumberContainers()
            {
                indexToNumber = new Dictionary<int, int>();
                numberToIndices = new Dictionary<int, SortedSet<int>>();
            }
            public void Change(int index, int number)
            {
                if (indexToNumber.ContainsKey(index))
                {
                    int oldNumber = indexToNumber[index];
                    numberToIndices[oldNumber].Remove(index);
                }

                indexToNumber[index] = number;

                if (!numberToIndices.ContainsKey(number))
                {
                    numberToIndices[number] = new SortedSet<int>();
                }
                numberToIndices[number].Add(index);
            }
            public int Find(int number)
            {
                if (!numberToIndices.ContainsKey(number) || numberToIndices[number].Count == 0)
                {
                    return -1;
                }

                return numberToIndices[number].Min;
            }
        }
    }
}