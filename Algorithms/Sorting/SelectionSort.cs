
namespace Sorting
{
    using Sorting.Abstractions;
    using System;
    using System.Collections.Generic;

    public class SelectionSort<T> : GeneralSortingAlgorithm<T>, ISortingAlgorithm<T> where T : IComparable<T>, new()
    {
        public IList<T> Sort(IList<T> array)
        {
            for (int i = 0; i < array.Count - 1; i++)
            {
                var minElementIndex = i;
                for (int j = i; j < array.Count; j++)
                {
                    if (array[j].CompareTo(array[minElementIndex]) == -1)
                    {
                        minElementIndex = j;
                    }
                }

                Swap(array, minElementIndex, i);
            }

            return array;
        }
    }
}
