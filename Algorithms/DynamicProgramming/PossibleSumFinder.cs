using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynamicProgramming
{
    /// <summary>
    ///     Problem: Write a function that by given sum and array of numbers returns a boolean indication
    ///     whether or not it is possible to generate the target sum from the numbers in the array.
    ///     Constraints:
    ///     - Element can be used as many times as needed.
    ///     - All input numbers are nonnegative.
    /// </summary>
    public class PossibleSumFinder
    {
        // 7, [5, 3, 4, 7]
        public bool Find(int sum, int[] numbers)
        {
            if (sum == 0) return true;
            if (sum < 0) return false;

            var result = false;
            foreach (var number in numbers)
            {
                result = result || Find(sum - number, numbers);
            }

            return result;
        }

        public bool FindWithEarlyReturn(int sum, int[] numbers)
        {
            if (sum == 0) return true;
            if (sum < 0) return false;

            foreach (var number in numbers)
            {
                if (FindWithEarlyReturn(sum - number, numbers) == true)
                {
                    return true;
                }
            }

            return false;
        }

        private Dictionary<int, bool> finderMemo = new Dictionary<int, bool>();

        public bool FindWithMemoization(int sum, int[] numbers)
        {
            if (sum == 0) return true;
            if (sum < 0) return false;
            if (finderMemo.ContainsKey(sum))
            {
                return finderMemo.GetValueOrDefault(sum);
            }

            foreach (var number in numbers)
            {
                if (FindWithMemoization(sum - number, numbers) == true)
                {
                    finderMemo.Add(sum, true);
                    return true;
                }
            }

            finderMemo.Add(sum, false);
            return false;
        }
    }
}
