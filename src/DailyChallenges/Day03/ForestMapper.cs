using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.DailyChallenges.Day03
{
    public static class ForestMapper
    {
        public static bool[,] Map(IEnumerable<string> data)
        {
            var values = data.ToArray();
            var row = 0;

            //assume that all lines are equal and fail latter if not;
            var map = new bool[values.Length, values[0].Length];
            foreach (var line in values)
            {
                var col = 0;
                foreach (var @char in line)
                {
                    map[row, col] = @char == '#';
                    col++;
                }

                row++;
            }
            return map;
        }
    }
}