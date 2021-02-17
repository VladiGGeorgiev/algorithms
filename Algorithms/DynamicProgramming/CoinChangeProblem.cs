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

        /// <summary>
        ///     Find the minumum number of coins needed to make a change
        /// </summary>
        /// <param name="change">Change</param>
        /// <param name="coins">Coin values</param>
        /// <returns>Minumum number of coins</returns>
        public long MinimunNumberOfCoinsToMakeChange(long change, List<long> coins)
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
    }
}
