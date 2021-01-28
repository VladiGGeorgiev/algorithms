namespace DynamicProgramming
{
    using System.Collections.Generic;

    public class Fibonacci
    {
        static Dictionary<int, int> fibonacciPairs = new Dictionary<int, int>();

        public int FibonacciMemoization(int n)
        {
            if (n <= 2)
            {
                return 1;
            }

            if (fibonacciPairs.ContainsKey(n))
            {
                return fibonacciPairs.GetValueOrDefault(n);
            }

            var value = FibonacciMemoization(n - 2) + FibonacciMemoization(n - 1);
            fibonacciPairs.Add(n, value);

            return value;
        }

        public int FibonacciRecursive(int n)
        {
            if (n <= 2)
            {
                return 1;
            }

            return FibonacciRecursive(n - 2) + FibonacciRecursive(n - 1);
        }
    }
}
