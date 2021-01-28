using System.Collections.Generic;

namespace DynamicProgramming
{
    public class GridTraveller
    {
        private static Dictionary<(int, int), int> gridTravels = new Dictionary<(int, int), int>();
        
        /// <summary>
        ///     Problem: In how many ways you can travel from the top left cell of a grid
        ///     to the bottom right cell of a grid. Find the number of paths.
        /// </summary>
        /// <param name="rows">Number of grid rows</param>
        /// <param name="cols">Number of grid columns</param>
        /// <returns>Number of ways to travel from top left to bottom right.</returns>
        public int TravelGrid(int rows, int cols)
        {
            if (rows == 0 || cols == 0) return 0;
            if (rows == 1 || cols == 1) return 1;

            // Going down + Goind right
            return TravelGrid(rows - 1, cols) + TravelGrid(rows, cols - 1);
        }

        public int TravelGridWithMemoization(int rows, int cols)
        {
            if (rows == 0 || cols == 0) return 0;
            if (rows == 1 || cols == 1) return 1;

            if (gridTravels.ContainsKey((rows, cols)))
            {
                return gridTravels.GetValueOrDefault((rows, cols));
            }

            if (gridTravels.ContainsKey((cols, rows)))
            {
                return gridTravels.GetValueOrDefault((cols, rows));
            }

            int result = TravelGridWithMemoization(rows - 1, cols) + TravelGridWithMemoization(rows, cols - 1);
            gridTravels.TryAdd((rows, cols), result);

            return result;
        }
    }
}
