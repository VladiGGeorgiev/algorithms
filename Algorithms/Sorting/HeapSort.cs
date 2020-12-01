using Sorting.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sorting
{
    public class HeapSort<T> : GeneralSortingAlgorithm<T>, ISortingAlgorithm<T> where T : IComparable<T>, new()
    {
        public IList<T> Sort(IList<T> array)
        {
            for (int i = array.Count / 2 - 1; i >= 0; i--)
            {
                MaxHeap(array, array.Count, i);
            }

            for (int i = array.Count - 1; i >= 0; i--)
            {
                Swap(array, 0, i);
                MaxHeap(array, i, 0);
            }

            return array;
        }

        private void MaxHeap(IList<T> array, int length, int index)
        {
            int largest = index;
            var leftChildIndex = index * 2 + 1;
            var rightChildIndex = index * 2 + 2;

            if (leftChildIndex < length && 
                array[largest].CompareTo(array[leftChildIndex]) == 1)
            {
                largest = leftChildIndex;
            }

            if (rightChildIndex < length &&
                array[largest].CompareTo(array[rightChildIndex]) == 1)
            {
                largest = rightChildIndex;
            }

            if (largest != index)
            {
                Swap(array, index, largest);
                MaxHeap(array, length, largest);
            }
        }

        private bool HasChild(int index, int arrayLength)
        {
            if ((index * 2) + 1 >= arrayLength)
            {
                return false;
            }

            return true;
        }
    }
}
