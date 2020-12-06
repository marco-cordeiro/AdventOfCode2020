using System.IO;

namespace AdventOfCode2020.DailyChallenges.Day03
{
    public static class ForestMapExtensions
    {
        public static int CountSlopeTrees(this bool[,] map, int rightSlope = 3, int downSlope = 1)
        {
            var x = 0;
            var xBounds = map.GetLength(1);
            var trees = 0;

            for (var y = downSlope; y < map.GetLength(0); y += downSlope)
            {
                x += rightSlope;

                if (x >= xBounds)
                    x -= xBounds;

                if (map[y, x])
                    trees++;
            }

            return trees;
        }

        public static void PrintMap(this bool[,] map, TextWriter output)
        {
            for (var i = 0; i < map.GetLength(0); i++)
            {
                if (i > 0)
                    output.WriteLine();
                for (var j = 0; j < map.GetLength(1); j++)
                {
                    output.Write(map[i, j] ? '#' : '.');
                }
            }
        }
    }
}