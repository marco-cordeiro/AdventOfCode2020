using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode2020.Framework;
using DataProvider;

namespace AdventOfCode2020
{
    public class ChallengeDay4 : IAdventCodeDayChallenge
    {
        private readonly IDataProvider<string> _dataProvider;
        private readonly TextWriter _output;

        public ChallengeDay4(IDataProvider<string> dataProvider, TextWriter output)
        {
            _dataProvider = dataProvider;
            _output = output;
        }

        public int Day => 4;

        public void Execute()
        {
            _output.WriteLine($"Advent of Code day {Day}");

            var passports = PassportReader.ReadPassports(_dataProvider.Read(Day)).ToArray();
                
            ResolvePart1(passports);
            ResolvePart2(passports);
        }

        private void ResolvePart1(IEnumerable<Passport> passports)
        {
            var validPassports = passports.Count(x => x.IsValid());
            _output.WriteLine($"\tFound {validPassports} valid passports");
        }

        private void ResolvePart2(IEnumerable<Passport> passports)
        {
            var validPassports = passports.Count(x => x.IsValid(true));
            _output.WriteLine($"\tFound {validPassports} valid passports (using strict rules)");
        }
    }
}