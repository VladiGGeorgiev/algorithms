namespace Sorting
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CountingSort : ISortingAlgorithm<int>
    {
        //{ 5, 3, 8, 10, 2, 6, 1, 3, 7, 2 }
        /// <summary>
        ///     Counting sort assumes that each of the n input elements is an integer in the range 0 to k, for some integer k.
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public IList<int> Sort(IList<int> array)
        {
            var maxElement = array.Max();
            var tempArray = new int[maxElement + 1];
            var sortedArray = new int[array.Count];

            for (int i = 0; i < array.Count; i++)
            {
                tempArray[array[i]]++;
            }

            for (int i = 1; i < tempArray.Length; i++)
            {
                tempArray[i] += tempArray[i - 1];
            }

            for (int i = array.Count - 1; i >= 0; i--)
            {
                sortedArray[tempArray[array[i]] - 1] = array[i];
                tempArray[array[i]]--;
            }

            return sortedArray;
        }
    }
}
