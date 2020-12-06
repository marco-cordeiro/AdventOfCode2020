using System.IO;
using AdventOfCode2020.Framework;
using DataProvider;

namespace AdventOfCode2020.DailyChallenges.Day19
{
    public class ChallengeDay19 : IAdventCodeDayChallenge
    {
        private readonly IDataProvider<int> _dataProvider;
        private readonly TextWriter _output;

        public ChallengeDay19(IDataProvider<int> dataProvider, TextWriter output)
        {
            _dataProvider = dataProvider;
            _output = output;
        }

        public int Day => 19;

        public void Execute()
        {
            _output.WriteLine($"Advent of Code day {Day}");

            ResolvePart1();
            ResolvePart2();
        }

        private void ResolvePart1()
        {
            _output.WriteLine($"\tPart 1 is not available");
        }

        private void ResolvePart2()
        {
            _output.WriteLine($"\tPart 2 is not available");
        }
    }
}