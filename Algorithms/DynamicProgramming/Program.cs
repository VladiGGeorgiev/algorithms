using System;
using System.Collections.Generic;

namespace DynamicProgramming
{
    public class Program
    {
        static void Main(string[] args)
        {
            int number = 10;
            var fibonacci = new Fibonacci();
            Console.WriteLine("Recursive fibonacci of {0}: {1}", number, fibonacci.FibonacciRecursive(number));
            Console.WriteLine("Recursive fibonacci with Memoization of {0}: {1}", number, fibonacci.FibonacciMemoization(number));

            Console.WriteLine();

            int rows = 17, cols = 17;
            var gridTraveller = new GridTraveller();
            var gridPaths = gridTraveller.TravelGrid(rows, cols);
            Console.WriteLine("Grid traveller ({0}, {1}) paths: {2}", rows, cols, gridPaths);
            var memoizedGridPaths = gridTraveller.TravelGridWithMemoization(rows, cols);
            Console.WriteLine("Grid traveller ({0}, {1}) paths: {2}", rows, cols, memoizedGridPaths);
        }
    }
}