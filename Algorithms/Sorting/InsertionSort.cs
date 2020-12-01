namespace Sorting
{
    using Sorting.Abstractions;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// We start with an empty left hand and the cards face down on the table.
    /// We then remove one card at a time from the table and insert it into the correct position in the left hand.
    /// To find the correct position for a card, we compare it with each of the cards already in the hand, 
    /// from right to left. At all times, the cards held in the left hand are sorted, 
    /// and these cards were originally the top cards of the pile on the table.
    /// 
    /// Insertion sort is an efficient algorithm for sorting a small number of elements.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class InsertionSort<T> : GeneralSortingAlgorithm<T>, ISortingAlgorithm<T> where T : IComparable<T>, new()
    {
        public IList<T> Sort(IList<T> array)
        {
            for (int i = 1; i < array.Count; i++)
            {
                int prevIndex = i - 1;

                while (prevIndex >= 0 && array[prevIndex].CompareTo(array[prevIndex + 1]) == 1)
                {
                    base.Swap(array, prevIndex, prevIndex + 1);
                    prevIndex--;
                }
            }

            return array;
        }
    }
}
