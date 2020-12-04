using System.IO;
using System.Linq;
using AdventOfCode2020.Framework;
using DataProvider;

namespace AdventOfCode2020
{
    public class ChallengeDay3 : IAdventCodeDayChallenge
    {
        private readonly IDataProvider<string> _dataProvider;
        private readonly TextWriter _output;

        public ChallengeDay3(IDataProvider<string> dataProvider, TextWriter output)
        {
            _dataProvider = dataProvider;
            _output = output;
        }

        public int Day => 3;

        public void Execute()
        {
            _output.WriteLine($"Advent of Code day {Day}");

            var map = ForestMapper.Map(_dataProvider.Read(Day));


            ResolvePart1(map);
            ResolvePart2(map);
        }

        private void ResolvePart1(bool[,] map)
        {
            var trees = map.CountSlopeTrees();

            _output.WriteLine($"\tWe're going to encounter {trees} trees");
        }

        private void ResolvePart2(bool[,] map)
        {
            var slopes = new (int r, int d)[]
            {
                (1, 1),
                (3, 1),
                (5, 1),
                (7, 1),
                (1, 2),
            };

            var slopesTrees = slopes.Select(x => map.CountSlopeTrees(x.r, x.d)).ToArray();
            var result = slopesTrees.Aggregate((a, b) => a * b);

            _output.WriteLine($"\tThe result of the multiplications for all slopes [{string.Join(", ", slopesTrees)}] is {result}");
        }
    }
}