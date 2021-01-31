using System;
using System.Collections.Generic;

namespace DynamicProgramming
{
    public class Program
    {
        static void Main(string[] args)
        {
            //int number = 10;
            //var fibonacci = new Fibonacci();
            //Console.WriteLine("Recursive fibonacci of {0}: {1}", number, fibonacci.FibonacciRecursive(number));
            //Console.WriteLine("Recursive fibonacci with Memoization of {0}: {1}", number, fibonacci.FibonacciMemoization(number));

            Console.WriteLine();

            //int rows = 17, cols = 17;
            //var gridTraveller = new GridTraveller();
            //var gridPaths = gridTraveller.TravelGrid(rows, cols);
            //Console.WriteLine("Grid traveller ({0}, {1}) paths: {2}", rows, cols, gridPaths);
            //var memoizedGridPaths = gridTraveller.TravelGridWithMemoization(rows, cols);
            //Console.WriteLine("Grid traveller ({0}, {1}) paths: {2}", rows, cols, memoizedGridPaths);

            Console.WriteLine();

            //var sumFinder = new PossibleSumFinder();
            //int sum = 7;
            //int[] numbers = new[] { 5, 3, 4, 7 };
            //Console.WriteLine("Sum: {0}; Nums: [5, 3, 4, 7]; Result: {1}", sum, sumFinder.Find(sum, numbers));
            //Console.WriteLine("Sum: 275; Nums: [7, 14]; Result: {0}", sumFinder.Find(275, new int[] { 7, 14 }));
            //Console.WriteLine("Sum: 275; Nums: [7, 14]; Result: {0}", sumFinder.FindWithEarlyReturn(275, new int[] { 7, 14 }));
            //Console.WriteLine("Sum: 275; Nums: [7, 14]; Result: {0}", sumFinder.FindWithMemoization(275, new int[] { 7, 14 }));
            //Console.WriteLine();

            var combinationSumFinder = new CombinationSumFinder();
            var result = combinationSumFinder.Find(7, new int[] { 5, 3, 4, 7 });

            var bestSumFinder = new BestSumFinder();
            var bestSumResult = bestSumFinder.Find(7, new int[] { 5, 3, 4, 7 });

            var stringConstructor = new StringConstructor();
            var canConstruct = stringConstructor.CanConstruct("skateboard", new string[] { "bo", "rd", "ate", "t", "ska", "sk", "boar" });
            var canConstruct2 = stringConstructor.CanConstruct("abcdef", new string[] { "ab", "abc", "cd", "def", "abcd" });
            var canConstruct3 = stringConstructor.CanConstruct("aaaaaaaaaaaaaaaaaaaaaaaaaw", new string[] { "a", "aa", "aaa", "aaaa", "aaaaa", "aaaaaa" });
            var canConstruct4 = stringConstructor.CanConstructWithMemoization("aaaaaaaaaaaaaaaaaaaaaaaaaw", new string[] { "a", "aa", "aaa", "aaaa", "aaaaa", "aaaaaa" });
        }
    }
}