using System;
using System.IO;
using System.Linq;
using System.Reflection;
using AdventOfCode2020.Framework;
using DataProvider;

namespace AdventOfCode2020.Day1
{
    public class ChallengeDay1 : IAdventCodeDayChallenge
    {
        private readonly IDataProvider<int> _dataProvider;
        private readonly TextWriter _output;

        public ChallengeDay1(IDataProvider<int> dataProvider, TextWriter output)
        {
            _dataProvider = dataProvider;
            _output = output;
        }

        public int Day => 1;

        public void Execute()
        {
            _output.WriteLine($"Advent of Code day {Day}");

            ResolvePart1();
            ResolvePart2();
        }

        private void ResolvePart1()
        {
            var data = _dataProvider.Read(Day).ToArray();

            try
            {
                var (value1, value2) = FindEntriesWithSum(data, 2020);

                _output.WriteLine($"\tThe two entries that sum to 2020 are {value1} and {value2}.");
                _output.WriteLine($"\tThe product of their multiplication is {value1 * value2}");
            }
            catch (AmbiguousMatchException)
            {
                _output.WriteLine("\tNo solution was found in the data set");
            }
        }

        private void ResolvePart2()
        {
            var data = _dataProvider.Read(Day).ToArray();

            try
            {
                var (value1, value2, value3) = Find3EntriesWithSum(data, 2020);

                _output.WriteLine($"\tThe three entries that sum to 2020 are {value1}, {value2} and {value3}.");
                _output.WriteLine($"\tThe product of their multiplication is {value1 * value2 * value3}");
            }
            catch (AmbiguousMatchException)
            {
                _output.WriteLine("\tNo solution was found in the data set");
            }
        }

        protected static (int, int) FindEntriesWithSum(int[] values, int sumValue)
        {
            for (var i = 0; i < values.Length - 1; i++)
            {
                for (var j = i + 1; j < values.Length; j++)
                {
                    var sum = values[i] + values[j];

                    if (sum == sumValue)
                        return (values[i], values[j]);
                }
            }

            throw new AmbiguousMatchException();
        }
        
        protected static (int, int, int) Find3EntriesWithSum(int[] values, int sumValue)
        {
            for (var i = 0; i < values.Length - 2; i++)
            {
                for (var j = i + 1; j < values.Length - 1; j++)
                {
                    for (int k = j + 1; k < values.Length; k++)
                    {
                        var sum = values[i] + values[j] + values[k];

                        if (sum == sumValue)
                            return (values[i], values[j], values[k]);
                    }
                }
            }

            throw new AmbiguousMatchException();
        }
    }
}