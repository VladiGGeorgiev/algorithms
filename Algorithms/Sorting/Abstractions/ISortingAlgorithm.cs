namespace Sorting
{
    using System;
    using System.Collections.Generic;

    public interface ISortingAlgorithm<T> where T : IComparable<T>, new()
    {
        IList<T> Sort(IList<T> array);
    }
}
