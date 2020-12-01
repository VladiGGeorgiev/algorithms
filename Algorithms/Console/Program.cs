using Sorting;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            // Insertion Sort
            var array = new List<int>() { 5, 3, 8, 10, 2, 6, 1, 3, 7, 2 };
            var sorting = new InsertionSort<int>();
            foreach (var item in sorting.Sort(array))
            {
                System.Console.WriteLine(item);
            }

            // Selection Sort
            var array2 = new List<int>() { 5, 3, 8, 10, 2, 6, 1, 3, 7, 2 };
            var selectionSort = new SelectionSort<int>();
            
            foreach (var item in selectionSort.Sort(array2))
            {
                System.Console.WriteLine(item);
            }

            var elements = 1000000;
            var rand = new Random();
            var sw = new Stopwatch();

            // Merge Sort
            var mergeArray = new List<int>() { 5, 3, 8, 10, 2, 6, 1, 3, 7, 2 };
            var heapArray = new List<int>() { 5, 3, 8, 10, 2, 6, 1, 3, 7, 2 };
            var heap2Array = new List<int>() { 5, 3, 8, 10, 2, 6, 1, 3, 7, 2 };
            for (int i = 0; i < elements; i++)
            {
                var num = rand.Next(10000000);
                mergeArray.Add(num);
                heapArray.Add(num);
                heap2Array.Add(num);
            }
            var mergeSort = new MergeSort<int>();
            sw.Start();
            var sortedArray = mergeSort.Sort(mergeArray);
            sw.Stop();
            System.Console.WriteLine(sw.Elapsed);
            //foreach (var item in sortedArray)
            //{
            //    System.Console.WriteLine(item);
            //}

            // Heap Sort
            for (int i = 0; i < elements; i++)
            {
                mergeArray.Add(rand.Next(10000000));
            }

            var heapSort = new HeapSortDraft<int>();
            sw.Reset();
            sw.Start();
            //var heapSortArray = heapSort.Sort(heapArray);
            sw.Stop();
            System.Console.WriteLine(sw.Elapsed);
            //foreach (var item in heapSortArray)
            //{
            //    System.Console.WriteLine(item);
            //}

            var heap2Sort = new HeapSort<int>();
            sw.Reset();
            sw.Start();
            var hpa = heap2Sort.Sort(heap2Array);
            sw.Stop();
            System.Console.WriteLine(sw.Elapsed);

            // Counting Sort
            var countingArray = new List<int>() { 5, 3, 8, 10, 2, 6, 1, 3, 7, 2 };
            var countingSort = new CountingSort();
            countingSort.Sort(countingArray);
        }
    }
}
