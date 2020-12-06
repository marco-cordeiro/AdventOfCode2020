using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode2020.Framework;
using DataProvider;

namespace AdventOfCode2020.DailyChallenges.Day06
{
    public class ChallengeDay6 : IAdventCodeDayChallenge
    {
        private readonly IDataProvider<string> _dataProvider;
        private readonly TextWriter _output;

        public ChallengeDay6(IDataProvider<string> dataProvider, TextWriter output)
        {
            _dataProvider = dataProvider;
            _output = output;
        }

        public int Day => 6;

        public void Execute()
        {
            _output.WriteLine($"Advent of Code day {Day}");

            var data = _dataProvider.Read(Day).ToArray();

            ResolvePart1(data);
            ResolvePart2(data);
        }

        private void ResolvePart1(IEnumerable<string> data)
        {
            var groupAnswers = GroupAnswersReader.CountAllAnswersForGroups(data).ToArray();
            var result = groupAnswers.Sum();
            _output.WriteLine($"\tThe sum of all group answers counts is {result}");
        }

        private void ResolvePart2(IEnumerable<string> data)
        {
            var groupAnswers = GroupAnswersReader.CountAllSameAnswersForGroups(data).ToArray();
            var result = groupAnswers.Sum();
            _output.WriteLine($"\tThe sum of all group common answers counts is {result}");
        }

    }
}