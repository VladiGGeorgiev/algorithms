namespace Sorting.Abstractions
{
    using System;
    using System.Collections.Generic;

    public abstract class GeneralSortingAlgorithm<T> where T : IComparable<T>, new()
    {
        protected void Swap(IList<T> array, int index1, int index2)
        {
            var value = array[index1];
            array[index1] = array[index2];
            array[index2] = value;
        }
    }
}
