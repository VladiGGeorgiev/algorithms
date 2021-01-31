using System.Collections.Generic;
using System.Linq;

namespace DynamicProgramming
{
    /// <summary>
    ///     Problem: Write a function that by given sum and array of numbers returns the shortest subset 
    ///     of numbers that add up to exactly the sum.
    ///     Constraints:
    ///     - If there are multiple shortest combinations you can return just one of them.
    /// </summary>
    public class BestSumFinder
    {
        // Find(7, [5, 3, 4, 7])
        public List<int> Find(int sum, int[] numbers)
        {
            if (sum == 0) return new List<int>();
            if (sum < 0) return null;

            var results = new List<List<int>>();
            foreach (var number in numbers)
            {
                var array = Find(sum - number, numbers);
                if (array != null)
                {
                    array.Add(number);
                    results.Add(array);
                }
            }

            if (results.Any())
            {
                return results.OrderBy(x => x.Count).FirstOrDefault();
            }

            return null;
        }

        public List<int> FindMemoryOptimization(int sum, int[] numbers)
        {
            if (sum == 0) return new List<int>();
            if (sum < 0) return null;

            var shortestResult = new List<int>();
            foreach (var number in numbers)
            {
                var array = Find(sum - number, numbers);
                if (array != null)
                {
                    array.Add(number);
                    if (array.Count < shortestResult.Count)
                    {
                        shortestResult = array;
                    }
                }
            }

            return shortestResult;
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

            var shortestResult = new List<int>();
            foreach (var number in numbers)
            {
                var array = Find(sum - number, numbers);
                if (array != null)
                {
                    array.Add(number);
                    if (array.Count < shortestResult.Count)
                    {
                        shortestResult = array;
                    }
                }
            }

            memoResults.Add(sum, shortestResult);
            return shortestResult;
        }
    }
}
