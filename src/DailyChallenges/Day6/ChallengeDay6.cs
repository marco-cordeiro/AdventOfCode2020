using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode2020.Framework;
using DataProvider;

namespace AdventOfCode2020
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

    public static class GroupAnswersReader
    {
        public static IEnumerable<int> CountAllSameAnswersForGroups(IEnumerable<string> data)
        {
            var passport = new List<int>();
            foreach (var groupAnswers in StreamAnswersPerGroup(data))
            {
                IEnumerable<char>? commonAnswers = null;
                foreach (var answers in groupAnswers)
                {
                    if (commonAnswers is null)
                    {
                        commonAnswers = answers.Select(x => x);
                        continue;
                    }

                    commonAnswers = commonAnswers.Intersect(answers);
                }

                yield return commonAnswers?.Count() ?? 0;
            }
        }       
        
        public static IEnumerable<int> CountAllAnswersForGroups(IEnumerable<string> data)
        {
            var passport = new List<int>();
            foreach (var groupAnswers in StreamAnswersPerGroup(data))
            {
                var answers = StreamGroupAnswers(groupAnswers);

                yield return answers.Distinct().Count();
            }
        }

        private static IEnumerable<char> StreamGroupAnswers(IEnumerable<string> data)
        {
            foreach (var line in data)
            {
                // returns all answers
                foreach (var @char in line)
                {
                    // ignores end of line characters
                    if (@char >= 'a' && @char <= 'z')
                        yield return @char;
                }
            }
        }
        private static IEnumerable<IEnumerable<string>> StreamAnswersPerGroup(IEnumerable<string> data)
        {
            var answers = new List<string>();
            
            foreach (var line in data)
            {
                // an empty line means that the group is over
                if (string.IsNullOrWhiteSpace(line))
                {
                    yield return answers;
                    answers = new List<string>();
                    continue;
                }

                answers.Add(line);
            }
            
            // just check if there is still a group answers in the buffer
            if (answers.Count > 0)
                yield return answers;
        }
    }
}