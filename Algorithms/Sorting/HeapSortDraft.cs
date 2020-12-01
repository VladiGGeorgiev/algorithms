using Sorting.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sorting
{
    public class HeapSortDraft<T> : GeneralSortingAlgorithm<T>, ISortingAlgorithm<T> where T : IComparable<T>, new()
    {
        public IList<T> Sort(IList<T> array)
        {
            MaxHeap(array, 0);
            for (int i = array.Count - 1; i > 0; i--)
            {
                Swap(array, 0, i);
                MaxHeap(array, 0, array.Count - i);
            }

            return array;
        }

        private void MaxHeap(IList<T> array, int parentIndex, int excludeElements = 0, bool oneLevel = false)
        {
            if (!HasChild(parentIndex, array.Count - excludeElements))
            {
                return;
            }

            var leftChildIndex = parentIndex * 2 + 1;
            MaxHeap(array, leftChildIndex, excludeElements);

            var rightChildIndex = parentIndex * 2 + 2;
            MaxHeap(array, rightChildIndex, excludeElements);

            if (array[parentIndex].CompareTo(array[leftChildIndex]) == -1)
            {
                Swap(array, parentIndex, leftChildIndex);
                MaxHeap(array, leftChildIndex, excludeElements, true);
            }

            if (rightChildIndex < array.Count - excludeElements && 
                array[parentIndex].CompareTo(array[rightChildIndex]) == -1)
            {
                Swap(array, parentIndex, rightChildIndex);
                MaxHeap(array, leftChildIndex, excludeElements, true);
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
