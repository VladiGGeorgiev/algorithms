namespace Test
{
    using System;
    using System.Collections.Generic;

    public class CoinChangeProblem
    {
        /// <summary>
        ///     Find the number of ways to make a change with given coins
        /// </summary>
        /// <param name="change">Change</param>
        /// <param name="coins">Coin values</param>
        /// <returns>Number of ways to make the change</returns>
        public long NumberOfWaysCoinsToMakeChange(long change, List<long> coins)
        {
            long[] array = new long[change + 1];
            array[0] = 1;

            foreach (var coin in coins)
            {
                for (int i = 1; i < array.Length; i++)
                {
                    if (i >= coin)
                    {
                        array[i] += array[i - coin];
                    }
                }
            }

            return array[change];
        }

        public long NumberNumberOfWaysCoinsToMakeChangeTopDown(long change, List<long> coins, int position = 0)
        {
            if (change == 0) return 1;
            if (change < 0) return 0;

            long ways = 0;
            for (int i = position; i < coins.Count; i++)
            {
                var way = NumberNumberOfWaysCoinsToMakeChangeTopDown(change - coins[i], coins, i);
                ways += way;
            }

            return ways;
        }

        /// <summary>
        ///     Find the minumum number of coins needed to make a change
        /// </summary>
        /// <param name="change">Change</param>
        /// <param name="coins">Coin values</param>
        /// <returns>Minumum number of coins</returns>
        public long MinimumNumberOfCoinsToMakeChange(long change, List<long> coins)
        {
            long[] array = new long[change + 1];
            Array.Fill(array, change + 1);
            array[0] = 0;

            for (int i = 1; i < array.Length; i++)
            {
                foreach (var coin in coins)
                {
                    if (i >= coin)
                    {
                        array[i] = Math.Min(array[i - coin] + 1, array[i]);
                    }
                }
            }

            return array[change];
        }

        public long MinimumNumberOfCoinsToMakeChangeTopDown(long change, List<long> coins, int position = 0)
        {
            if (change == 0) return 1;
            if (change < 0) return 0;

            long minWays = change;
            for (int i = position; i < coins.Count; i++)
            {
                var ways = 1 + MinimumNumberOfCoinsToMakeChangeTopDown(change - coins[i], coins, i);
                if (ways < minWays)
                {
                    minWays = ways;
                }
            }

            return minWays;
        }
    }
}
