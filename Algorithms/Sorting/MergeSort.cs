namespace Sorting
{
    using Sorting.Abstractions;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MergeSort<T> : GeneralSortingAlgorithm<T>, ISortingAlgorithm<T> where T : IComparable<T>, new()
    {
        public IList<T> Sort(IList<T> array)
        {
            Devide(array, 0, array.Count - 1);
            return array;
        }

        private void Devide(IList<T> array, int left, int right)
        {
            if (left == right)
            {
                return;
            }

            var middle = (right + left) / 2;
            Devide(array, left, middle);
            Devide(array, middle + 1, right);

            Merge(array, left, middle, right);
        }

        private void Merge(IList<T> array, int left, int middle, int right)
        {
            var leftArray = array.Skip(left).Take(middle - left + 1).ToList();
            var rightArray = array.Skip(middle + 1).Take(right - middle).ToList();

            int leftIndex = 0;
            int rightIndex = 0;
            for (int i = left; i < right + 1; i++)
            {
                if (leftIndex == leftArray.Count)
                {
                    array[i] = rightArray[rightIndex];
                    rightIndex++;
                }
                else if (rightIndex == rightArray.Count)
                {
                    array[i] = leftArray[leftIndex];
                    leftIndex++;
                }
                else if (leftArray[leftIndex].CompareTo(rightArray[rightIndex]) == -1)
                {
                    array[i] = leftArray[leftIndex];
                    leftIndex++;
                }
                else
                {
                    array[i] = rightArray[rightIndex];
                    rightIndex++;
                }
            }
        }
    }
}
