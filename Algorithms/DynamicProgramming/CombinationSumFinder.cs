using System.Collections.Generic;

namespace DynamicProgramming
{
    /// <summary>
    ///     Problem: Write a function that by given sum and array of numbers returns a subset of the numbers 
    ///     that add up to exactly the sum.
    ///     Constraints:
    ///     - If there are multiple combinations you can return just one of them.
    /// </summary>
    public class CombinationSumFinder
    {
        public List<int> Find(int sum, int[] numbers)
        {
            if (sum == 0) return new List<int>();
            if (sum < 0) return null;

            foreach (var number in numbers)
            {
                var array = Find(sum - number, numbers);
                if (array != null)
                {
                    array.Add(number);
                    return array;
                }
            }

            return null;
        }

        private Dictionary<int, List<int>> memoResults = new Dictionary<int, List<int>>();

        public List<int> FindWithMemoization(int sum, int[] numbers)
        {
            if (sum == 0) return new List<int>();
            if (sum < 0) return null;
            if (memoResults.ContainsKey(sum))
            {
                return memoResults.GetValueOrDefault(sum);
            }

            foreach (var number in numbers)
            {
                var array = FindWithMemoization(sum - number, numbers);
                if (array != null)
                {
                    array.Add(number);
                    memoResults.Add(sum, array);
                    return array;
                }
            }

            memoResults.Add(sum, null);
            return null;
        }
    }
}
