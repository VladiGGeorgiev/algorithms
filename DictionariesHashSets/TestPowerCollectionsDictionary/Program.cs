using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace TestPowerCollectionsDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<int, int> dict = new SortedDictionary<int, int>();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 1000000; i++)
            {
                dict.Add(i, (i + 8) / 3);
            }

            for (int i = 0; i < 1000000; i++)
            {
                dict.ContainsKey(i);
            }
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
            sw.Reset();
            OrderedDictionary<int, int> dict2 = new OrderedDictionary<int, int>();
            sw.Start();
            for (int i = 0; i < 1000000; i++)
            {
                dict2.Add(i, (i + 8) / 3);
            }

            for (int i = 0; i < 1000000; i++)
            {
                dict.ContainsKey(i);
            }
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
        }
    }
}
